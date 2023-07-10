namespace RetailStore.Application.DTO;

public class InvoiceDto
{
    public InvoiceDto()
    {
        Bill = new BillDto();
    }

    public BillDto Bill { get; set; }
    
    public float Gross { get; set; }
    public string Net { get; set; }
}