using System.Data;
using Npgsql;

namespace TaxSlabCalculator.Infrastructure.Persistance;

public class TaxSlabDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public TaxSlabDbContext( IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString =  _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(_connectionString));
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
}