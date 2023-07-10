namespace RetailStore.Domain.Rules;

// If the user has been a customer for over 2 years, he gets a 5% discount.
public class CustomerOver2YearsDiscountRule : PercentageDiscountRule
{
    public CustomerOver2YearsDiscountRule() 
        : base(0.05f, b => DateTime.Now.Year - b.Customer.CreatedAt.Year >= 2)
    {
    }
}