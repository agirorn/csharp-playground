namespace Acme.Hello.Logic;

public class HelloLogicFactory : IHelloLogicFactory
{
    public IHelloLogic CreateHelloLogic(DapperContext context)
    {
        return new HelloTransactionalLogic(context);
    }
}
