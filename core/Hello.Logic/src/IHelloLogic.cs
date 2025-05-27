using HelloModel = Acme.Hello.Model.Hello;

public interface IHelloLogic
{
    Task<HelloModel?> GetHelloAsync();
}
