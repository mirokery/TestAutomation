using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation.Framework.Configurations;

namespace TestAutomation.UITests.Common.Fixtures;

[SetUpFixture]
public class BrowserFixture
{
    public static IWebDriver Driver { get; private set; }
    
    public static void Initialize()
    {   
        var headless =
            bool.Parse(Framework.Common.GlobalSetup.Configuration[ConfigurationVariables.IsBrowserHeadless] ?? "true");
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        if (headless)
        {
            options.AddArgument("--headless");
        }
        
        Driver = new ChromeDriver(options);
        var url = Framework.Common.GlobalSetup.Configuration[ConfigurationVariables.UIUrl];
        Driver.Navigate().GoToUrl(url);
    }
    
    public static void CleanUp()
    {
        Driver.Dispose();
    }
}
    