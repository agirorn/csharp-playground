using Acme.Hello.DAO;

namespace Acme.Hello.Logic;

public class HelloLogic(IHelloDao dao) : IHelloLogic
{
    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        return await dao.GetHelloAsync();
    }

    public async Task CreateHello()
    {
        await dao.CreateHelloAsync("first");
        await dao.CreateHelloAsync("second");
    }

    public async Task CreateHelloFail()
    {
        await dao.CreateHelloAsync("first");
        throw new Exception("fail");
        await dao.CreateHelloAsync("second");
    }
}