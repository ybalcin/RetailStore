namespace RetailStore.Domain.Models;

public class Invoice
{
    public Bill Bill { get; set; }
    
    public float Gross { get; set; }
    public float Net { get; set; }
}