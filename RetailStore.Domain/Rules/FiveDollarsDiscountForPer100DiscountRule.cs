using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;

namespace RetailStore.Domain.Rules;

// For every $100 on the bill, there would be a $ 5 discount
public class FiveDollarsDiscountForPer100DiscountRule : Rule
{
    private const float Discount = 5f;

    public override void Check(Bill bill)
    {
        if (bill.Gross < 100) return;

        var discount = (float)Math.Floor(bill.Net / 100) * Discount;
        bill.ApplicableDiscounts.Add(new Discount
        {
            Amount = discount,
            Type = DiscountType.Cash
        });
    }
}