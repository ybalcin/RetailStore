using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;

namespace RetailStore.Domain.Rules;

// The percentage based discounts do not apply on groceries.
public abstract class PercentageDiscountRule : Rule
{
    private readonly float _discount;
    private readonly Func<Bill, bool> _condition;

    protected PercentageDiscountRule(float discount, Func<Bill, bool> condition)
    {
        _discount = discount;
        _condition = condition;
    }
    
    public override void Check(Bill bill)
    {
        if (!_condition.Invoke(bill)) return;

        var isThereNotGrocery = bill.Basket.Any(f => f.Product.Category == ProductCategory.NotGrocery);
        if (!isThereNotGrocery) return;
        
        bill.ApplicableDiscounts.Add(new Discount
        {
            Amount = _discount,
            Type = DiscountType.Percentage
        });
    }
}