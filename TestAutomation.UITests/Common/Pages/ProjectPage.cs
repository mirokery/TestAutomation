using FluentAssertions;
using OpenQA.Selenium;
using TestAutomation.UITests.Common.Helpers;

namespace TestAutomation.UITests.Common.Pages;

public class ProjectPage
{
    private readonly IWebDriver _driver;

    public ProjectPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public async Task ElementVisible()
    {   
        Helpers.Helpers.WaitUntilElementExists( _driver,By.XPath(DinosaurusLabel));
    }
    public async Task UploadImage(DinosaurusEnum dinosaurusName)
    {
        _driver.FindElement(By.XPath(BrowseFile)).SendKeys($@"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Inputs\{dinosaurusName.ToString()}.JPG");
        _driver.FindElement(By.XPath(UploadButton)).Click();
    }

    public async Task PickTask(TaskEnum taskName)
    {
        if (taskName == TaskEnum.classify)
        {
            _driver.FindElement(By.XPath(ClassifierButton)).Click();
        }
        if (taskName == TaskEnum.detect)
        {
            _driver.FindElement(By.XPath(DetectionButton)).Click();
        }
        if (taskName == TaskEnum.segment)
        {
            _driver.FindElement(By.XPath(SegmentationButton)).Click();
        }
    }

    public async Task CheckResult(DinosaurusEnum dinosaurusName)
    {   
        Helpers.Helpers.WaitUntilElementExists( _driver,By.XPath(Result));
        _driver.FindElement(By.XPath(Result)).Text.Should().Contain(dinosaurusName.ToString());
    }
    public async Task GoToHomePage()
    {
        _driver.FindElement(By.XPath(HomePageLocator)).Click();
    }
    
    private string HomePageLocator = "//div/a[text()='To Home Page']";
    private string DinosaurusLabel = "//div/h1[text()='Dinosaurus Dataset']";
    private string ClassifierButton = "//div/button[text()='Object Classifier']";
    private string DetectionButton = "//div/button[text()='Object Detector']";
    private string SegmentationButton = "//div/button[text()='Object segmentation']";
    private string BrowseFile = "//div/input[@type='file']";
    private string UploadButton = "//div/button[text()='Upload']";
    private string Result = "//pre";

}