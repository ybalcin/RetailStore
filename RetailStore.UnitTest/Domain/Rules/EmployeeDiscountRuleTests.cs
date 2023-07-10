using System.Diagnostics.CodeAnalysis;
using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Rules;

namespace RetailStore.UnitTest.Domain.Rules;

[ExcludeFromCodeCoverage]
public class EmployeeDiscountRuleTests
{
    [Fact]
    public void employees_should_have_30_percentage_discount_for_not_grocery_products()
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
                        Price = 100
                    }
                }
            }
        };

        new EmployeeDiscountRule().Check(bill);

        Assert.Equal(bill.ApplicableDiscounts.FirstOrDefault(), new Discount
        {
            Type = DiscountType.Percentage,
            Amount = 0.3f
        });
    }
    
    [Fact]
    public void employees_cannot_have_30_percentage_discount_for_grocery_products()
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
                        Category = ProductCategory.Grocery,
                        Price = 100
                    }
                }
            }
        };

        new EmployeeDiscountRule().Check(bill);

        Assert.Empty(bill.ApplicableDiscounts);
    }
    
    [Fact]
    public void not_employee_customers_cannot_have_30_percentage_discount()
    {
        var bill = new Bill
        {
            Customer = new Customer
            {
                Type = UserType.Affiliate
            },
            Basket = new List<BasketProduct>
            {
                new()
                {
                    Product = new Product
                    {
                        Category = ProductCategory.NotGrocery,
                        Price = 100
                    }
                }
            }
        };

        new EmployeeDiscountRule().Check(bill);

        Assert.Empty(bill.ApplicableDiscounts);
    }
}