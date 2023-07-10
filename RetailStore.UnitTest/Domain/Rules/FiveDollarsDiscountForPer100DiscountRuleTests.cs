using System.Diagnostics.CodeAnalysis;
using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Rules;

namespace RetailStore.UnitTest.Domain.Rules;

[ExcludeFromCodeCoverage]
public class FiveDollarsDiscountForPer100DiscountRuleTests
{
    [Theory]
    [InlineData(100, 95)]
    [InlineData(900, 855)]
    [InlineData(99, 99)]
    public void customer_should_have_5_dollars_discount_for_per_100_dollars(float price, float expectedNet)
    {
        var bill = new Bill
        {
            Customer = new Customer
            {
                Type = UserType.Employee
            },
            Basket = new List<BasketProduct>
            {
                new()
                {
                    Product = new Product
                    {
                        Category = ProductCategory.NotGrocery,
                        Price = price
                    }
                }
            }
        };

        new FiveDollarsDiscountForPer100DiscountRule().Check(bill);
        Helper.ApplyDiscounts(bill);

        Assert.Equal(expectedNet, bill.Net);
    }
}