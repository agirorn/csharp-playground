using Acme.Hello.DAO;
using HelloModel = Acme.Hello.Model.Hello;

namespace Acme.Hello.Logic.IntegrationTests;

public class HelloDaoTests
{
    private class FakeHelloDao : IHelloDao
    {
        public Task<HelloModel?> GetHelloAsync()
        {
            return Task.FromResult<HelloModel?>(new HelloModel
            {
                Content = "Hello, world!"
            });
        }
    }

    [Fact]
    public async Task GetHelloAsync_ReturnsHelloWorldContent()
    {
        var logic = new HelloLogic(new FakeHelloDao());
        var hello = await logic.GetHelloAsync();

        Assert.NotNull(hello);
        Assert.Equal("Hello, world!", hello!.Content);
    }
}
