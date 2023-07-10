namespace RetailStore.Domain.Models;

public class Discount
{
    public float Amount { get; set; }
    public string Type { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        
        var other = (Discount)obj!;
        return other.Amount == Amount && other.Type == Type;
    }
}