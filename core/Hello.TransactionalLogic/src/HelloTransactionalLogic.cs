using System;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HelloModel = Acme.Hello.Model.Hello;
using Acme.Hello.DAO;

public class HelloTransactionalLogic(DapperContext context)
{

    private readonly DapperContext context = context
      ?? throw new InvalidOperationException("Missing context.");

    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        IHelloDao dao = new HelloDao(this.context.CreateConnection());
        var logic = new HelloLogic(dao);

        HelloModel? res = await logic.GetHelloAsync();
        return res;
    }

    public async Task<T> Transaction<T>(Func<DbConnection, Task<T>> func)
    {
        IDbConnection connection = this.context.CreateConnection();
        const string begin_sql = "BEGIN;";
        await connection.QueryFirstOrDefaultAsync(begin_sql);

        try
        {
            // Set the transaction to the connection if your DAO needs it
            var result = await func(connection);
            // await transaction.CommitAsync();

            const string commit_sql = "COMMIT;";
            await connection.QueryFirstOrDefaultAsync(commit_sql );
            return result;
        }
        catch
        {

            const string rollback_sql = "ROLLBACK;";
            await connection.QueryFirstOrDefaultAsync(rollback_sql);
            throw;
        }
    }
}
