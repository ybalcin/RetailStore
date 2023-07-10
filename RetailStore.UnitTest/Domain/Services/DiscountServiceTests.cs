using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Services;

namespace RetailStore.UnitTest.Domain.Services;

public class DiscountServiceTests
{
    private List<DiscountTestData> TestTable =>
        new()
        {
            new DiscountTestData
            {
                Bill = new Bill
                {
                    Customer = new Customer
                    {
                        Type = UserType.Employee,
                        CreatedAt = DateTime.Now.AddYears(-2)
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
                                Category = ProductCategory.NotGrocery,
                                Price = 200
                            }
                        }
                    }
                },
                ExpectedApplicableDiscountCount = 3,
                ExpectedNet = 200f,
            },
            new DiscountTestData
            {
                Bill = new Bill
                {
                    Customer = new Customer
                    {
                        Type = UserType.Affiliate,
                        CreatedAt = DateTime.Now.AddYears(-2)
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
                                Category = ProductCategory.NotGrocery,
                                Price = 200
                            }
                        }
                    }
                },
                ExpectedApplicableDiscountCount = 3,
                ExpectedNet = 260f,
            },
            new DiscountTestData
            {
                Bill = new Bill
                {
                    Customer = new Customer
                    {
                        Type = UserType.Affiliate,
                        CreatedAt = DateTime.Now.AddYears(-2)
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
                        },
                        new()
                        {
                            Product = new Product
                            {
                                Category = ProductCategory.Grocery,
                                Price = 200
                            },
                            Count = 2
                        }
                    }
                },
                ExpectedApplicableDiscountCount = 1,
                ExpectedNet = 475f,
            },
            new DiscountTestData
            {
                Bill = new Bill
                {
                    Customer = new Customer
                    {
                        Type = UserType.Affiliate,
                        CreatedAt = DateTime.Now.AddYears(-2)
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
                        },
                        new()
                        {
                            Product = new Product
                            {
                                Category = ProductCategory.NotGrocery,
                                Price = 200
                            },
                            Count = 2
                        }
                    }
                },
                ExpectedApplicableDiscountCount = 3,
                ExpectedNet = 440f,
            }
        };

    [Fact]
    public void should_apply_max_percentage_discount()
    {
        foreach (var t in TestTable)
        {
            new DiscountService().ApplyDiscount(t.Bill);

            Assert.Equal(t.ExpectedApplicableDiscountCount, t.Bill.ApplicableDiscounts.Count);
            Assert.Equal(t.ExpectedNet, t.Bill.Net);
        }
    }
}

public class DiscountTestData
{
    public Bill Bill { get; set; }
    public int ExpectedApplicableDiscountCount { get; set; }
    public float ExpectedNet { get; set; }
}