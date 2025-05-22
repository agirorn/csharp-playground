using Dapper;

using Hello.Model;

using System.Data;

namespace Hello.DAO;

public class HelloDao : IHelloDao
{
    private readonly IDbConnection connection;

    public HelloDao(IDbConnection connection)
    {
        this.connection = connection;
    }

    public async Task<Hello?> GetHelloAsync()
    {
        const string query = "SELECT content FROM hello LIMIT 1";
        return await connection.QueryFirstOrDefaultAsync<Hello>(query);
    }
}
