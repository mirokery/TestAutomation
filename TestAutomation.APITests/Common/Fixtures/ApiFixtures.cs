using TestAutomation.APITests.Client;

namespace TestAutomation.APITests.Common.Fixtures;

[SetUpFixture]
public class ApiFixture
{
    public static ApiClient Client { get; private set; }

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        Client = new ApiClient();
        TestContext.Progress.WriteLine("ApiClient initialized globally.");
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Client = null;
        TestContext.Progress.WriteLine("ApiClient cleaned up.");
    }
}