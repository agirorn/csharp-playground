using System;
using System.Data;
using System.Threading.Tasks;

using Acme.Hello.DAO;
using Acme.Hello.Model;

using Npgsql;

// using Xunit;

namespace Acme.Hello.DAO.IntegrationTests;

public class HelloDaoTests
{
    private const string ConnectionString =
        "Host=localhost;Database=hello_test;Username=admin;Password=admin";

    [Fact]
    public async Task GetHelloAsync_ReturnsHelloWorldContent()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        await connection.OpenAsync();

        var dao = new HelloDao(connection);

        Acme.Hello.Model.Hello? result = await dao.GetHelloAsync();

        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result!.Content));
        Assert.Equal("Hello World", result.Content); // adjust to expected DB value
    }
}
