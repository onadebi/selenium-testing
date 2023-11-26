using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testing_selenium;

public class TestSuiteone : IDisposable
{

    private readonly IWebDriver _driver;
    public TestSuiteone()
    {
        var options = new ChromeOptions();

        #region Headless-> This makes Selenium run in the background, without opening a browser window.
        // options.AddArgument("headless");
        #endregion

        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
    }
    [Fact]
    public void WebsiteHomePageHasTitle()
    {
        _driver.Navigate().GoToUrl("https://onadebi.com/");
        string title = _driver.Title;
        Assert.False(String.IsNullOrWhiteSpace(title));
    }

    [Fact]
    public void WebsiteContent()
    {
        _driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
        string title = _driver.Title;
        Assert.False(String.IsNullOrWhiteSpace(title));
    }

    //This uses the Dispose method of the IDisposable interface to close the browser after the test is run.
    public void Dispose()
    {
        Thread.Sleep(3000);
        _driver.Quit();
        GC.SuppressFinalize(this);
    }

}
