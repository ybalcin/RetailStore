using RetailStore.Domain.Models;

namespace RetailStore.Domain.Rules;

public abstract class Rule
{
    public abstract void Check(Bill bill);
}