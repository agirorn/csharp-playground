using Acme.Hello.DAO;
using Acme.Hello.Logic;
using Microsoft.AspNetCore.Mvc;
using HelloModel = Acme.Hello.Model.Hello;

[ApiController]
[Route("[controller]")]
public class HelloController(DapperContext context, IHelloLogicFactory logicFactory) : ControllerBase
{
    private readonly DapperContext context = context;

    [HttpGet]
    public async Task<IActionResult> GetHello()
    {
        IHelloDao dao = new HelloDao(context.CreateConnection());
        var logic = new HelloLogic(dao);

        HelloModel? res = await logic.GetHelloAsync();
        return res == null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> PostHello()
    {
        IHelloLogic logic = logicFactory.CreateHelloLogic(context);
        await logic.CreateHello();

        return Ok();
    }
}
