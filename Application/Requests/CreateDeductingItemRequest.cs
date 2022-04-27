namespace TaxSlabCalculator.Application.Requests;

public record CreateDeductingItemRequest(string ItemName, int Amount);