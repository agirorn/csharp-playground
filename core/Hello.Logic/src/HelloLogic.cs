using Acme.Hello.DAO;

public class HelloLogic(IHelloDao dao)
{
    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        return await dao.GetHelloAsync(); // Use directly
    }
}
