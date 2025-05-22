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
