// using HelloWorldAllInOneWebServer.Data;
// using HelloWorldAllInOneWebServer.Models;
using Dapper;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class HelloController(DapperContext context) : ControllerBase
{
    private readonly DapperContext context = context ?? throw new InvalidOperationException(
              "Missing context.");

    [HttpGet]
    public async Task<IActionResult> GetHello()
    {
        var query = "SELECT content FROM hello LIMIT 1";
        using System.Data.IDbConnection connection = this.context.CreateConnection();
        Hello? result = await connection.QueryFirstOrDefaultAsync<Hello>(query);
        return result == null ? this.NotFound() : this.Ok(result);
    }
}
