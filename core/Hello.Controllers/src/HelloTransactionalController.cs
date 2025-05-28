using Acme.Hello.Logic;
using Microsoft.AspNetCore.Mvc;
using HelloModel = Acme.Hello.Model.Hello;

namespace Acme.Hello.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloTransactionalController(DapperContext context) : ControllerBase
{
    private readonly DapperContext context = context ?? throw new InvalidOperationException(
        "Missing context.");

    [HttpGet]
    public async Task<IActionResult> GetHello()
    {
        IHelloLogic logic = new HelloTransactionalLogic(this.context);
        HelloModel? res = await logic.GetHelloAsync();
        return res == null ? this.NotFound() : this.Ok(res);
    }
}