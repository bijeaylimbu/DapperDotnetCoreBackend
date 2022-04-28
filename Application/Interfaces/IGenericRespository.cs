using TaxSlabCalculator.Application.Requests;
using TaxSlabCalculator.Application.Responses;
using TaxSlabCalculator.Core.Entities;

namespace TaxSlabCalculator.Application.Interfaces;

public interface IGenericRespository
{
 Task<int> CreatePerson(CreatePersonRequest createPerson);
 Task<int> CreatePayableItem(CreatePayableItemRequest request, int PersonId);
 Task<int> CreateDeductionItem(CreateDeductingItemRequest request, int PersonId);
 Task<IReadOnlyList<object>> GetAllPayableItem( int id);
 Task<IReadOnlyList<object>> GetAllDeductionItem(int id );
 Task<PayableItem> GetPayableItemById(int id);
 Task<DeductingItem> GetDeductingItemById(int id);
 Task UpdatePayableItem(UpdatePayableItemRequest request, int id);
 Task UpdateDeductionItem(UpdateDeductingItemRequest request, int id);
 Task DeletePayableItemById(int id);
 Task DeleteDeductingItemById(int id);
 Task<IReadOnlyList<Person>> GetAllPersonName();
}