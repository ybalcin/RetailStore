using RetailStore.Application.DTO;

namespace RetailStore.Application.Services.Abstract;

public interface IInvoiceAppService
{
    public InvoiceDto CreateInvoice(BillDto billDto);
}