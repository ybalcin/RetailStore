using RetailStore.Domain.Models;

namespace RetailStore.Domain.Services.Abstract;

public interface IDiscountService
{
    public void ApplyDiscount(Bill bill);
}