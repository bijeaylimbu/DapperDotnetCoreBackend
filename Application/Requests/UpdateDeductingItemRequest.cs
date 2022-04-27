namespace TaxSlabCalculator.Application.Requests;

public record UpdateDeductingItemRequest(string ItemName, int Amount);