using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Acme.Hello.DAO;
using Dapper;
using HelloModel = Acme.Hello.Model.Hello;

public class HelloTransactionalLogic(DapperContext context)
{
    private readonly DapperContext context = context
      ?? throw new InvalidOperationException("Missing context.");

    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        using IDbConnection connection = this.context.CreateConnection();
        {
            IHelloDao dao = new HelloDao(connection);
            var logic = new HelloLogic(dao);

            HelloModel? res = await logic.GetHelloAsync();
            return res;
        }
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
