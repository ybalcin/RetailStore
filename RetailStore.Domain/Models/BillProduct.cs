using System.Text.Json.Serialization;

namespace RetailStore.Domain.Models;

public class BasketProduct
{
    public Product Product { get; set; }
    public int Count { get; set; } = 1;

    private float _totalPrice;

    [JsonIgnore]
    public float TotalPrice
    {
        get
        {
            if (_totalPrice > 0) return _totalPrice;

            _totalPrice = Product.Price * Count;
            return _totalPrice;
        }
        set => _totalPrice = value;
    }
}