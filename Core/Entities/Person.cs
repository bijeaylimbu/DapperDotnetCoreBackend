namespace TaxSlabCalculator.Core.Entities;

public class Person
{
    public int Id { get; init; }
    public string Name { get; init; }
    public List<PayableItem> PayableItems { get; init; } = new List<PayableItem>();
    public List<DeductingItem> DeductingItems { get; init; } = new List<DeductingItem>();
}