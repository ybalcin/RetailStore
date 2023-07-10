using System.Diagnostics.CodeAnalysis;
using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Rules;

namespace RetailStore.UnitTest.Domain.Rules;

[ExcludeFromCodeCoverage]
public class CustomerOver2YearsDiscountRuleTests
{
    [Fact]
    public void customer_for_over_2_years_should_have_5_percentage_discount_for_not_grocery_products()
    {
        var createdAt = DateTime.Now.AddYears(-2);
        
        var bill = new Bill
        {
            Customer = new Customer
            {
                Type = UserType.Affiliate,
                CreatedAt = createdAt
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
        
        new CustomerOver2YearsDiscountRule().Check(bill);
        
        Assert.Equal(bill.ApplicableDiscounts.FirstOrDefault(), new Discount
        {
            Type = DiscountType.Percentage,
            Amount = 0.05f
        });
    }
    
    [Fact]
    public void customer_for_not_over_2_years_should_not_have_5_percentage_discount()
    {
        var bill = new Bill
        {
            Customer = new Customer
            {
                Type = UserType.Affiliate,
                CreatedAt = DateTime.Now
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
        
        new CustomerOver2YearsDiscountRule().Check(bill);
        
        Assert.Empty(bill.ApplicableDiscounts);
    }
    
    [Fact]
    public void customer_for_over_2_years_cannot_have_5_percentage_discount_for_grocery_products()
    {
        var createdAt = DateTime.Now.AddYears(-2);
        
        var bill = new Bill
        {
            Customer = new Customer
            {
                Type = UserType.Affiliate,
                CreatedAt = createdAt
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
        
        new CustomerOver2YearsDiscountRule().Check(bill);
        
        Assert.Empty(bill.ApplicableDiscounts);
    }
}