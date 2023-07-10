using RetailStore.Domain.Models;

namespace RetailStore.Application.DTO;

public class BillDto
{
    public BillDto()
    {
        Basket = new List<BasketProduct>();
        Customer = new Customer();
    }
    
    public Customer Customer { get; set; }
    public List<BasketProduct> Basket { get; set; }
}