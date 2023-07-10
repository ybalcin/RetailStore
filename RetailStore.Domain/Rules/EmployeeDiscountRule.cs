using RetailStore.Domain.Enums;

namespace RetailStore.Domain.Rules;

// If the user is an employee of the store, he gets a 30% discount
public class EmployeeDiscountRule : PercentageDiscountRule
{
    public EmployeeDiscountRule() : base(0.3f, b => b.Customer.Type == UserType.Employee)
    {
    }
}