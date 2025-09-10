using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestAutomation.UITests.Common.Helpers;

public class Helpers
{   
   
    public static bool IsElementVisible(IWebElement element)
    {
        return element.Displayed && element.Enabled;
    }
    
   public static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 10)
   {
       try
       {
           var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
           return wait.Until(ExpectedConditions.ElementExists(elementLocator));
       }
       catch (NoSuchElementException)
       {
           Console.WriteLine($"Element with locator: '{elementLocator}' was not found in current context page.");
           throw;
       }
   }
   
}