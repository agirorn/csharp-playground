using Dapper;

using System.Data;

namespace Acme.Hello.DAO;

public class HelloDao(IDbConnection connection) : IHelloDao
{
    private readonly IDbConnection connection = connection;

    public async Task<Model.Hello?> GetHelloAsync()
    {
        const string query = "SELECT content FROM hello LIMIT 1";
        return await this.connection.QueryFirstOrDefaultAsync<Model.Hello>(query);
    }

    public async Task CreateHelloAsync(string content)
    {
        const string query = "INSERT INTO hello (content) VALUES (@content)";
        await this.connection.ExecuteAsync(query, new {
            content });
    }
}
