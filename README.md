# C# playgrond

## Folder Structure
core/Hello.DAO/HelloDao.cs

core/Hello.DAO/tests/integration/

core/Hello.Model/tests/unit/


/MySolution
├── MySolution.sln
├── apps/
│   ├── ServerX/
│   │   ├── ServerX.csproj
│   │   └── tests/
│   │       └── ServerX.Tests.csproj
│   └── ServerY/
│       ├── src
│       ├── ServerY.csproj
│       └── tests/
│           └── ServerY.Tests.csproj
├── workers/
│   ├── WorkerX/
│   │   ├── WorkerX.csproj
│   │   └── tests/
│   │       └── WorkerX.Tests.csproj
│   └── WorkerY/
│       ├── src
│       ├── WorkerY.csproj
│       └── tests/
│           └── WorkerY.Tests.csproj
├── core/
│   ├── Hello.DAO/
│   │   ├── tests/
│   │   │   └── integration/
│   │   │       └── Hello.DAO.IntegrationTests.csproj
│   │   └── Hello.DAO.csproj
│   │
│   ├── Hello.Model/
│   │   ├── tests/
│   │   │   └── unit/
│   │   │       └── Hello.Model.UnitTests.csproj
│   │   └── Hello.Model.csproj
│   │
│   └── Cart/
│       ├── Cart.Domain/
│       │   ├── src
│       │   ├── Cart.Domain.csproj
│       │   └── tests/
│       │       ├── unit/
│       │       │   └── Cart.Domain.UnitTests.csproj
│       │       └── integration/
│       │           └── Cart.Domain.IntegrationTests.csproj
│       ├── Cart.Model/
│       │   ├── Cart.Model.csproj
│       │   └── tests/
│       │       ├── unit/
│       │       │   └── Cart.Model.UnitTests.csproj
│       │       └── integration/
│       │           └── Cart.Model.IntegrationTests.csproj


# C# playgrond

## Folder Structure

/MySolution
├── Acme.sln
├── apps/
│   ├── App.X/
│   │   ├── src
│   │   ├── Acme.ServerX.csproj
│   │   └── tests/
│   │       └── Acme.ServerX.Tests.csproj
│   └── App.Y/
│       ├── src
│       ├── ServerY.csproj
│       └── tests/
│           └── ServerY.Tests.csproj
├── workers/
│   ├── Worker.X/
│   │   ├── src
│   │   ├── Acme.WorkerX.csproj
│   │   └── tests/
│   │       └── Acme.WorkerX.Tests.csproj
│   └── Worker.Y/
│       ├── src
│       ├── Acme.WorkerY.csproj
│       └── tests/
│           └── Acme.WorkerY.Tests.csproj
├── core/
│   └── Cart/
│       ├── Cart.Domain/
    │       │   ├── src
│       │   │   └── Acme.Cart.Domain.csproj
│       │   └── tests/
│       │       ├── unit/
│       │       │   └── Acme.Cart.Domain.UnitTests.csproj
│       │       └── integration/
│       │           └── Acme.Cart.Domain.IntegrationTests.csproj
│       ├── Cart.Model/
│       │   ├── Acme.Cart.Model.csproj
│       │   └── tests/
│       │       ├── unit/
│       │       │   └── Acme.Cart.Model.UnitTests.csproj
│       │       └── integration/
│       │           └── Acme.Cart.Model.IntegrationTests.csproj


**Next itteration**
```cs
using System.Transactions;
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
        return this.Ok(await transaction(async (con) =>
        {
            IHelloDao dao = new HelloDao(con);
            var logic = new HelloLogic(dao);

            HelloModel? res = await logic.GetHelloAsync();
            return res;
        }));
    }
}

public class HelloController(IHelloLogic logic) : ControllerBase
[HttpGet]
public async Task<IActionResult> GetHello()
{
    HelloModel? res = await logic.GetHelloAsync();
    return res == null ? this.NotFound() : this.Ok(res);
}
}


public class HelloController(IHelloLogic logic) : ControllerBase
[HttpGet]
public async Task<IActionResult> GetHello()
{
    return this.Ok(await logic.GetHelloAsync());
}
}

public class HelloLogic(IHelloDao dao)  : IHelloLogic
{
    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        return await dao.GetHelloAsync(); // Use directly
    }
}

class HelloTransactionalLogic : TransactionBase, IHelloLogic
{
    public async Task<Acme.Hello.Model.Hello?> GetHelloAsync()
    {
        return await this.Transaction(async (con) =>
        {
            return await new HelloLogic(new HelloDao(con)).GetHelloAsync();
        });
    }
}
```
