using OpenQA.Selenium;
using TestAutomation.UITests.Common.Fixtures;
using TestAutomation.UITests.Common.Helpers;

namespace TestAutomation.UITests.Common.Pages;

public class HomePage:BrowserFixture
{
    private readonly IWebDriver _driver;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public async Task GoToHomePage()
    {
        _driver.FindElement(By.XPath(HomePageLocator)).Click();
    }
    public async Task GoToProjectPage()
    {   
      
       Helpers.Helpers.WaitUntilElementExists( _driver,By.XPath(HomePageLocator));
       _driver.FindElement(By.XPath(ProjectPageLocator)).Click();
       
    }
    
  
    private string HomePageLocator = "//div/a[text()='To Home Page']";
    private string ProjectPageLocator = "//div/a[text()='Go To Project Page']";
}