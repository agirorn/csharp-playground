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

            // await logic.CreateHelloFail();
            await logic.CreateHello();
            return null;
        });
    }

    private async Task<T> Transaction<T>(Func<IDbConnection, Task<T>> func)
    {
        using IDbConnection connection = this.context.CreateConnection();
        connection.Open();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            T result = await func(connection);
            transaction.Commit();
            return result;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}