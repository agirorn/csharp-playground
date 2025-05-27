using System.Data;
using Acme.Hello.DAO;
using Acme.Hello.Logic;
using Dapper;
using HelloModel = Acme.Hello.Model.Hello;

namespace Acme.Hello.TransactionalLogic;

public class HelloTransactionalLogic(DapperContext context) : IHelloLogic
{
    private readonly DapperContext context = context
        ?? throw new InvalidOperationException("Missing context.");

    public async Task<HelloModel?> GetHelloAsync()
    {
        using IDbConnection connection = context.CreateConnection();
        {
            IHelloDao dao = new HelloDao(connection);
            var logic = new HelloLogic(dao);

            HelloModel? res = await logic.GetHelloAsync();
            return res;
        }
    }

    public async Task CreateHello()
    {
        await this.Transaction<Task>(async (connection) =>
        {
            IHelloDao dao = new HelloDao(connection);
            var logic = new HelloLogic(dao);

            await logic.CreateHello();
            return null;
        });
    }

    public async Task<T> Transaction<T>(Func<IDbConnection, Task<T>> func)
    {
        using IDbConnection connection = this.context.CreateConnection();
        _ = await connection.ExecuteAsync("BEGIN;");
        try
        {
            T result = await func(connection);
            _ = await connection.ExecuteAsync("COMMIT;");
            return result;
        }
        catch
        {
            _ = await connection.ExecuteAsync("ROLLBACK;");
            throw;
        }
    }
}