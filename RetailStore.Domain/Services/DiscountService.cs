using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Rules;
using RetailStore.Domain.Services.Abstract;

namespace RetailStore.Domain.Services;

/*
If the user is an employee of the store, he gets a 30% discount
If the user is an affiliate of the store, he gets a 10% discount
If the user has been a customer for over 2 years, he gets a 5% discount.
For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
The percentage based discounts do not apply on groceries.
A user can get only one of the percentage based discounts on a bill.
 */

public class DiscountService : IDiscountService
{
    public void ApplyDiscount(Bill bill)
    {
        new AffiliateDiscountRule().Check(bill);
        new CustomerOver2YearsDiscountRule().Check(bill);
        new EmployeeDiscountRule().Check(bill);
        ApplyPercentageDiscounts(bill);
        
        new FiveDollarsDiscountForPer100DiscountRule().Check(bill);
        ApplyCashDiscount(bill);
    }
    
    private static void ApplyPercentageDiscounts(Bill bill)
    {
        var percentageDiscount = bill.ApplicableDiscounts.Where(f => f.Type == DiscountType.Percentage)
            .MaxBy(d => d.Amount);
        if (percentageDiscount != null)
        {
            var notGroceryProducts = bill.Basket
                .Where(p => p.Product.Category == ProductCategory.NotGrocery)
                .ToList();
            var gross = notGroceryProducts.Sum(s => s.TotalPrice);
            var totalDiscount = gross * percentageDiscount.Amount;

            var discountPerProduct =
                float.Parse((totalDiscount / notGroceryProducts.Sum(p => p.Count)).ToString("0.00"));
            
            foreach (var p in bill.Basket)
            {
                p.TotalPrice -= discountPerProduct;
            }
        }

        var net = bill.Basket.Sum(p => p.TotalPrice);
        
        bill.Net = net < 0 ? 0 : net;
    }

    private static void ApplyCashDiscount(Bill bill)
    {
        var cashDiscount = bill.ApplicableDiscounts.FirstOrDefault(s => s.Type == DiscountType.Cash);
        if (cashDiscount != null)
        {
            bill.Net -= cashDiscount.Amount;
        }
        
        if (bill.Net < 0) bill.Net = 0;
    }
}