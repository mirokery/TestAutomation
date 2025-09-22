using TechTalk.SpecFlow;
using TestAutomation.APITests.Common.Fixtures;

namespace TestAutomation.APITests.Common.Tests.Hooks;

[Binding]
public class ApiHooks
{
    [BeforeScenario("api")] 
    public void BeforeApiScenario()
    {
        ApiFixture.Initialize();
    }

    [AfterScenario("api")]
    public void AfterApiScenario()
    {
        ApiFixture.CleanUp();
    }
}