using TestAutomation.APITests.Client;

namespace TestAutomation.APITests.Common.Fixtures;


public class ApiFixture
{
    public static ApiClient Client { get; private set; }

    [OneTimeSetUp]
    public static void Initialize()
    {
        Client = new ApiClient();
        TestContext.Progress.WriteLine("ApiClient initialized globally.");
    }

    [OneTimeTearDown]
    public static void CleanUp()
    {
        Client = null;
        TestContext.Progress.WriteLine("ApiClient cleaned up.");
    }
}