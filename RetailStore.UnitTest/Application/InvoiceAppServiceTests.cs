using System.Diagnostics.CodeAnalysis;
using RetailStore.Application.DTO;
using RetailStore.Application.Services;
using RetailStore.Domain.Enums;
using RetailStore.Domain.Models;
using RetailStore.Domain.Services;

namespace RetailStore.UnitTest.Application;

[ExcludeFromCodeCoverage]
public class InvoiceAppServiceTests
{
    [Fact]
    public void CreateInvoiceTest()
    {
        var billDto = new BillDto
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
        
        var bill = new Bill
        {
            Customer = billDto.Customer,
            Basket = billDto.Basket
        };

        var appService = new InvoiceAppService(new DiscountService());

        var expected = new InvoiceDto
        {
            Bill = billDto,
            Gross = bill.Gross,
            Net = "70,00"
        };
        var actual = appService.CreateInvoice(billDto);
        
        Assert.Equal(expected.Net, actual.Net);
    }
}