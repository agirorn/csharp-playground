# C# playgrond

## Folder Structure

/MySolution
├── MySolution.sln
├── apps/
│   ├── ServerX/
│   │   ├── src
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
│   │   ├── src
│   │   ├── WorkerX.csproj
│   │   └── tests/
│   │       └── WorkerX.Tests.csproj
│   └── WorkerY/
│       ├── src
│       ├── WorkerY.csproj
│       └── tests/
│           └── WorkerY.Tests.csproj
├── core/
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
