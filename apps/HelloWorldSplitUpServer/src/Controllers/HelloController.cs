using Acme.Hello.DAO;
using Microsoft.AspNetCore.Mvc;
using HelloModel = Acme.Hello.Model.Hello;

[ApiController]
[Route("[controller]")]
public class HelloController(DapperContext context) : ControllerBase
{
    private readonly DapperContext context = context ?? throw new InvalidOperationException(
              "Missing context.");

    [HttpGet]
    public async Task<IActionResult> GetHello()
    {
        IHelloDao dao = new HelloDao(this.context.CreateConnection());
        HelloModel? res = await dao.GetHelloAsync();
        return res == null ? this.NotFound() : this.Ok(res);
    }
}
