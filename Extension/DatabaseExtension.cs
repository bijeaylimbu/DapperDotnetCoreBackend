using System.Reflection;
using DbUp;

namespace TaxSlabCalculator.Extension;

public static class DatabaseExtension
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var configuration = services.GetRequiredService<IConfiguration>();
            // var logger = services.GetRequiredService<ILogger<TContext>>();
            // logger.LogInformation("Migrating postgres database");
            string connection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            EnsureDatabase.For.PostgresqlDatabase(connection);
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connection)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
            var result = upgrader.PerformUpgrade();
            if (!result.Successful)
            {
                // logger.LogError(result.Error, "An error occur while performing migraion");
                return host;
            }
            // logger.LogInformation("Migrated postgresql database");
        }

        return host;
    }
}