using RetailStore.Application.DTO;
using RetailStore.Application.Services.Abstract;
using RetailStore.Domain.Models;
using RetailStore.Domain.Services.Abstract;

namespace RetailStore.Application.Services;

public class InvoiceAppService : IInvoiceAppService
{
    private readonly IDiscountService _discountService;

    public InvoiceAppService(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public InvoiceDto CreateInvoice(BillDto billDto)
    {
        var bill = new Bill
        {
            Customer = billDto.Customer,
            Basket = billDto.Basket
        };
        
        _discountService.ApplyDiscount(bill);

        return new InvoiceDto
        {
            Bill = billDto,
            Gross = bill.Gross,
            Net = bill.Net.ToString("0.00")
        };
    }
}