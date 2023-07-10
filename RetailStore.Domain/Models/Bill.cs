namespace RetailStore.Domain.Models;

public class Bill
{
    public Bill()
    {
        Basket = new List<BasketProduct>();
        ApplicableDiscounts = new List<Discount>();
        Customer = new Customer();
    }

    public Customer Customer { get; set; }

    public List<BasketProduct> Basket { get; set; }

    public List<Discount> ApplicableDiscounts { get; set; }

    private float _net;

    public float Net
    {
        get
        {
            if (_net > 0) return _net;

            _net = Gross;
            return _net;
        }
        set => _net = value;
    }

    private float _gross;

    public float Gross
    {
        get
        {
            if (_gross > 0) return _gross;

            _gross = CalculateGross();
            return _gross;
        }
    }

    private float CalculateGross()
    {
        return Basket.Sum(p => p.Product.Price * p.Count);
    }
}