namespace RetailStore.Domain.Models;

public class Product
{
    public string Category { get; set; }
    public float Price { get; set; }

    // private float _discountedPrice;
    //
    // public float DiscountedPrice
    // {
    //     get
    //     {
    //         if (!(_discountedPrice <= 0)) return _discountedPrice;
    //         
    //         _discountedPrice = Price;
    //         return _discountedPrice;
    //     }
    //     set => _discountedPrice = value;
    // }
}