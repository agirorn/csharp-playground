using Xunit;
// using Hello.Model;
using Acme.Hello.Model;

// namespace Hello.Model.IntegrationTests;

public class HelloModelTests
{
    [Fact]
    public void Hello_Content_Should_Be_Set()
    {
        // var hello = new P.Hello.Model.Hello { Content = "Hello World" };
        var hello = new Acme.Hello.Model.Hello { Content = "Hello World" };

        Assert.Equal("Hello World", hello.Content);
    }
}
