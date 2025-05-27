namespace Acme.Hello.Logic;

public interface IHelloLogic
{
    Task<Acme.Hello.Model.Hello?> GetHelloAsync();

    Task CreateHello();
}
