namespace TestAutomation.APITests.Common.Fixtures;

[SetUpFixture]
public class TestHook
{
    [OneTimeSetUp]
    public void BeforeAllTests() => ApiFixture.Initialize();

    [OneTimeTearDown]
    public void AfterAllTests() => ApiFixture.CleanUp();
}
