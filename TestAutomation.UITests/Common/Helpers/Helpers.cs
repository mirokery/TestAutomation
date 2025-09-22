using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace TestAutomation.UITests.Common.Helpers;
[Binding]
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
   
   [StepArgumentTransformation]
   public TaskEnum TransformToTaskEnum(string taskName)
   {
       return Enum.Parse<TaskEnum>(taskName, true);
   }
   [StepArgumentTransformation]
   public DinosaurusEnum TransformToDinosaurusEnum(string dinosaurusName)
   {
       return Enum.Parse<DinosaurusEnum>(dinosaurusName, true);
   }
   
}