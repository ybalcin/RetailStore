using RetailStore.Domain.Enums;

namespace RetailStore.Domain.Rules;

// If the user is an affiliate of the store, he gets a 10% discount
public class AffiliateDiscountRule : PercentageDiscountRule
{
    public AffiliateDiscountRule() : base(0.1f, b => b.Customer.Type == UserType.Affiliate)
    {
    }
}