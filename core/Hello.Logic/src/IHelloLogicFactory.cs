namespace Acme.Hello.Logic;

public interface IHelloLogicFactory
{
    public IHelloLogic CreateHelloLogic(DapperContext context);
}
