public class HelloModelTests
{
    [Fact]
    public void HelloContentShouldBeSet()
    {
        var hello = new Acme.Hello.Model.Hello { Content = "Hello World" };

        Assert.Equal("Hello World", hello.Content);
    }
}
