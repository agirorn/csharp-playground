using Acme.Hello.Logic;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<IHelloLogicFactory, HelloLogicFactory>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllers();
builder.Services.AddSingleton<StartupValidator>();

WebApplication app = builder.Build();

// Configure middleware
app.MapControllers();
app.Run("http://localhost:8080");
