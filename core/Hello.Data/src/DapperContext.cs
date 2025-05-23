using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

public class DapperContext
{
    private readonly string connectionString;

    public DapperContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSQL")
          ?? throw new InvalidOperationException(
              "Missing PostgreSQL connection string on key 'PostgreSQL'.");
        this.connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(this.connectionString);
    }
}
