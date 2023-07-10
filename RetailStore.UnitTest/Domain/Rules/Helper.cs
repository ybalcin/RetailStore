using System.Diagnostics.CodeAnalysis;
using RetailStore.Domain.Models;

namespace RetailStore.UnitTest.Domain.Rules;

[ExcludeFromCodeCoverage]
public static class Helper
{
    public static void ApplyDiscounts(Bill bill)
    {
        foreach (var d in bill.ApplicableDiscounts)
        {
            bill.Net -= d.Amount;
        }
    }
}