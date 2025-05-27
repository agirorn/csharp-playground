namespace Acme.Hello.DAO;

public interface IHelloDao
{
    public Task<Model.Hello?> GetHelloAsync();
    
    public Task CreateHelloAsync(string content);
}
