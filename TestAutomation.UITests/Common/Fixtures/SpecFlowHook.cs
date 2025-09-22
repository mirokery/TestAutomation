using TechTalk.SpecFlow;
using TestAutomation.UITests.Common.Fixtures;

namespace TestAutomation.UITests.Common.Tests.Hooks;

[Binding]
public sealed class SpecFlowHook
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        BrowserFixture.Initialize();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        BrowserFixture.CleanUp();
    }
}