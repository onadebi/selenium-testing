using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing_selenium.Data;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace testing_selenium
{
    /// <summary>
    /// This TestSuite uses the DriverManager package.
    /// Best forwhen you have no control over the broswers and their versions that would be running on the server machines
    /// It would be responsible for downloading the correct versions of the browsers required to run the tests
    /// </summary>
    public class TestSuiteTwoDriverManager : IDisposable
    {
        private readonly IWebDriver _driver;
        public static TheoryData<string> WeblinkData => WebSiteData.WeblinkData;
        public static TheoryData<string> extUrl => WebSiteData.MockedUrl;

        public TestSuiteTwoDriverManager() {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var options = new ChromeOptions();
            // options.AddArguments(["--headless"]);
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);
        }

        [Theory(DisplayName = "WebsiteHomePage Has Title", Skip ="This is already shown in TestSuiteOne. Not needed here for now.")]
        [MemberData(nameof(WeblinkData))]
        public void WebsiteHomePageHasTitlez(string urlLink)
        {
            _driver.Navigate().GoToUrl(urlLink);
            string pageTitle = _driver.Title;
            Assert.False(String.IsNullOrWhiteSpace(pageTitle));
        }

        [Theory,MemberData(memberName:nameof(extUrl))]
        public void ProperValueAddedAndConfirmedbasedOnElementOnPage(string extUrl)
        {
            _driver.Navigate().GoToUrl(extUrl);
            IWebElement todoInpElement = _driver.FindElement(By.Id("sampletodotext"));
            IWebElement addbutton = _driver.FindElement(By.Id("addbutton"));

            string textAdded = DateTime.Now.AddDays(1).ToString("d");
            todoInpElement.SendKeys(textAdded);
            addbutton.Click();

            // Retrieve details by using XPath - Validate in browser, before transfer to use here.
            IEnumerable<IWebElement> todoCheckboxesList = _driver.FindElements(By.XPath("//li[@ng-repeat]/input"));
            IEnumerable<IWebElement> todoCheckboxesTextValue = _driver.FindElements(By.XPath("//li[@ng-repeat]/span"));

            var TodoItemCheckBox = todoCheckboxesList.Last();
            var TodoItemTextLabel = todoCheckboxesTextValue.Last();

            Assert.Equal(textAdded, TodoItemTextLabel.Text);

            TodoItemCheckBox?.Click();
                Thread.Sleep(2000);
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            _driver.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
