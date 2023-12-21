using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
using testing_selenium.Data;

namespace testing_selenium;

public class TestSuiteone : IDisposable
{

    private readonly IWebDriver _driver;

    public static TheoryData<string> WeblinkData => WebSiteData.WeblinkData;
    public TestSuiteone()
    {
        var options = new ChromeOptions();

        #region Headless-> This makes Selenium run in the background, without opening a browser window.
        options.AddArgument("headless");
        #endregion

        _driver = new ChromeDriver(options);
        _driver.Manage().Window.Maximize();
    }

    [Fact]
    [Trait("Category", "CI")]
    [Trait("Priority", "1")]
    public void CheckNotEmpty()
    {
        Assert.False(String.IsNullOrWhiteSpace("NotEmpty"));
    }

    [Fact]
    public void WebsiteHomePageHasTitle()
    {
        _driver.Navigate().GoToUrl("https://onaxsys.com/");
        string title = _driver.Title;
        Assert.False(String.IsNullOrWhiteSpace(title));
    }

    /// <summary>
    /// Check that a website has a titile using Firefox
    /// </summary>
    [Theory(DisplayName = "WebsiteHomePage Has Title")]
    [MemberData(nameof(WeblinkData))]
    public void WebsiteHomePageHasTitlez(string urlLink)
    {
        _driver.Navigate().GoToUrl(urlLink);
        string pageTitle = _driver.Title;
        Assert.False(String.IsNullOrWhiteSpace(pageTitle));
    }

    [Fact]
    public void WebsiteContent()
    {
        _driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
        string title = _driver.Title;
        Assert.False(String.IsNullOrWhiteSpace(title));
    }

    //This uses the Dispose method of the IDisposable interface to close the browser after the test is run.
    // An alternative to not implmenting and using the IDisposable/Dispose(is to make use of "using" statement to initialize the IWebDiver and its operations in a function code block
    public void Dispose()
    {
        Thread.Sleep(3000);
        _driver.Quit();
        GC.SuppressFinalize(this);
    }

}
