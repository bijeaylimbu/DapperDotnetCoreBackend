using Dapper;
using TaxSlabCalculator.Infrastructure.Persistance;

namespace TaxSlabCalculator.Migrations;

public class Database
{
    private readonly TaxSlabDbContext _context;

    public Database(TaxSlabDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void CreateDataBase(string dbName)
    {
        var query = "SELECT *FROM sys.databases WHERE name=@name";
        var parameters = new DynamicParameters();
        parameters.Add("name", dbName);
        using (var connection=_context.CreateConnection())
        {
            var records = connection.Query(query, parameters);
            if (!records.Any())
                connection.Execute($"CREATE DATABASE {dbName}");
        }
    }
}