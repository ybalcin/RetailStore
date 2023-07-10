using Microsoft.AspNetCore.Mvc;
using RetailStore.Application.DTO;
using RetailStore.Application.Services.Abstract;

namespace RetailStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceAppService _invoiceAppService;

    public InvoiceController(IInvoiceAppService invoiceAppService)
    {
        _invoiceAppService = invoiceAppService;
    }

    [HttpPost]
    public ActionResult CreateInvoice(BillDto dto)
    {
        var invoiceDto = _invoiceAppService.CreateInvoice(dto);
        
        return Ok(invoiceDto);
    }
}