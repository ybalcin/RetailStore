using System.Diagnostics.CodeAnalysis;
using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Rules;

namespace RetailStore.UnitTest.Domain.Rules;

[ExcludeFromCodeCoverage]
public class AffiliateDiscountRuleTests
{
    [Fact]
    public void affiliate_users_should_have_10_percentage_discount_for_not_grocery_products()
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
                },
                new()
                {
                    Product = new Product
                    {
                        Category = ProductCategory.Grocery,
                        Price = 200
                    }
                }
            }
        };

        new AffiliateDiscountRule().Check(bill);

        Assert.Equal(bill.ApplicableDiscounts.FirstOrDefault(), new Discount
        {
            Amount = 0.1f,
            Type = DiscountType.Percentage
        });
    }

    [Fact]
    public void affiliate_users_cannot_have_10_percentage_discount_for_grocery_products()
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
                        Category = ProductCategory.Grocery,
                        Price = 100
                    }
                }
            }
        };
        
        new AffiliateDiscountRule().Check(bill);
        
        Assert.Empty(bill.ApplicableDiscounts);
    }

    [Fact]
    public void not_affiliate_users_cannot_have_10_percentage_discount()
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
        
        new AffiliateDiscountRule().Check(bill);
        
        Assert.Empty(bill.ApplicableDiscounts);
    }
}