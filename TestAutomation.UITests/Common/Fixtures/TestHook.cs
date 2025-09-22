namespace TestAutomation.UITests.Common.Fixtures;

[SetUpFixture]
public class TestHook
{
    [OneTimeSetUp]
    public void BeforeAllTests() => BrowserFixture.Initialize();

    [OneTimeTearDown]
    public void AfterAllTests() => BrowserFixture.CleanUp();
}

