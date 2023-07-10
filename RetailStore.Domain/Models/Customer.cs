namespace RetailStore.Domain.Models;

public class Customer
{
    public Customer()
    {
        CreatedAt = DateTime.Now;
    }
    
    public string Type { get; set; }
    public DateTime CreatedAt { get; set; }
}