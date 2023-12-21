using Xunit;


namespace testing_selenium.Data;
public static class WebSiteData{

    public static TheoryData<string> WeblinkData => new TheoryData<string> { "https://www.onaxsys.com" };
    public static TheoryData<string> MockedUrl => new (){ "https://lambdatest.github.io/sample-todo-app/" };

}
