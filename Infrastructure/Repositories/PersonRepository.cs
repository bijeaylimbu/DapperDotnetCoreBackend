
using Dapper;
using TaxSlabCalculator.Application.Interfaces;
using TaxSlabCalculator.Application.Requests;
using TaxSlabCalculator.Core.Entities;
using TaxSlabCalculator.Infrastructure.Persistance;

namespace TaxSlabCalculator.Infrastructure.Repositories;

public class PersonRepository: IPersonRepository
{
    private readonly TaxSlabDbContext _context;

    public PersonRepository(TaxSlabDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<int> CreatePerson(CreatePersonRequest request)
    {
        var query = "INSERT INTO Person(NAME ) VALUES (@NAME ) RETURNING id";
        var parameters = new DynamicParameters();
        parameters.Add("Name", request.Name);
        using (var connection = _context.CreateConnection())
        {
            var result = await connection.ExecuteScalarAsync<int>(query, parameters);
            return result;
        }
    }

    public async Task<int> CreatePayableItem(CreatePayableItemRequest request, int PersonId )
    {
        var query = "INSERT INTO payable_item(item_name, amount,person_id ) VALUES (@ItemName, @Amount , @PersonId) RETURNING id";
        var parameters = new DynamicParameters();
        parameters.Add("ItemName", request.ItemName);
        parameters.Add("Amount", request.Amount);
        parameters.Add("PersonId", PersonId);
        using (var connection = _context.CreateConnection())
        {
            var result=   await connection.ExecuteScalarAsync<int>(query, parameters);
         return result;
        }
    }

    public async Task<int> CreateDeductionItem(CreateDeductingItemRequest request, int PersonId)
    {
        var query = "INSERT INTO deducting_item(item_name, amount, person_id ) VALUES (@ItemName, @Amount, @PersonId ) RETURNING id";
        var parameters = new DynamicParameters();
        parameters.Add("ItemName", request.ItemName);
        parameters.Add("Amount", request.Amount);
        parameters.Add("PersonId", PersonId);
        using (var connection = _context.CreateConnection())
        {
          var result= await connection.ExecuteScalarAsync<int>(query, parameters);
          return result;
        }
    }

    public async Task< IEnumerable<PayableItem>> GetAllPayableItem()
    {
        var query = "SELECT item_name, amount FROM payable_item";
        using (var connection = _context.CreateConnection())
        {
            var payableItem = await connection.QueryAsync<PayableItem>(query);
            return payableItem.ToList();
        }
    }

    public async Task<IEnumerable<DeductingItem>> GetAllDeductionItem()
    {
        var query = "SELECT item_name, amount FROM deducting_item";
        using (var connection = _context.CreateConnection())
        {
            var deductingItem = await connection.QueryAsync<DeductingItem>(query);
            return deductingItem.ToList();
        }
    }

    public async Task<PayableItem> GetPayableItemById(int id)
    {
        var query = "SELECT * FROM payable_item WHERE id=@id";
        using (var connection = _context.CreateConnection())
        {
            var payableItem = await connection.QueryFirstOrDefaultAsync<PayableItem>(query, new {id});
            return payableItem;
        }
    }

    public async Task<DeductingItem> GetDeductingItemById(int id)
    {
        var query = "SELECT * FROM deducting_item WHERE id=@id";
        using (var connection = _context.CreateConnection())
        {
            var deductingItem = await connection.QueryFirstOrDefaultAsync<DeductingItem>(query, new {id});
            return deductingItem;
        }
    }

    public async Task UpdatePayableItem(UpdatePayableItemRequest request, int id)
    {
        var query = "UPDATE payable_item SET item_name= @ItemName, amount= @Amount WHERE id= @id ";
        var parameters = new DynamicParameters();
        parameters.Add("ItemName", request.ItemName);
        parameters.Add("Amount", request.Amount);
        parameters.Add("Id", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDeductionItem(UpdateDeductingItemRequest request, int id)
    {
        var query = "UPDATE deducting_item SET item_name = @ItemName, amount = @Amount WHERE id= @Id ";
        var parameters = new DynamicParameters();
        parameters.Add("ItemName", request.ItemName);
        parameters.Add("Amount", request.Amount);
        parameters.Add("Id", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeletePayableItemById(int id)
    {
        var query = "DELETE FROM payable_item WHERE Id=@Id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new {id});
        }
    }

    public async Task DeleteDeductingItemById(int id)
    {
        var query = "DELETE FROM deducting_item WHERE Id=@Id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new {id});
        }
    }
}