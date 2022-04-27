namespace TaxSlabCalculator.Core.Entities;

public class DeductingItem
{
    public int Id { get; init; }
    public string ItemName { get; init; }
    public int Amount { get; init; }
    public int PersonId { get; }
}