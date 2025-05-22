namespace Acme.Hello.DAO;

public interface IHelloDao
{
    Task<Model.Hello?> GetHelloAsync();
}
