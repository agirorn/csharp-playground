using Xunit;
// using Hello.Model;
using Acme.Hello.Model;

// using Acme;

public class HelloModelTests
{
    [Fact]
    public void HelloContentShouldBeSet()
    {
        // var hello = new P.Hello.Model.Hello { Content = "Hello World" };
        var hello = new Acme.Hello.Model.Hello { Content = "Hello World" };

        Assert.Equal("Hello World", hello.Content);
    }
}
