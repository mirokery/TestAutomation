
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomation.UITests.Common.Fixtures;
using TestAutomation.UITests.Common.Helpers;
using TestAutomation.UITests.Common.Pages;

namespace TestAutomation.UITests.Common.Tests.StepDefinitions;

[Binding]
public class ClassifySteps
{
    private readonly HomePage _homePage;
    private readonly ProjectPage _projectPage;
    private IWebDriver driver;
    
    public ClassifySteps()
    {   
        driver = BrowserFixture.Driver; 
        _homePage = new HomePage(driver);
        _projectPage = new ProjectPage(driver);
    }
   
    
    [Given(@"I navigate to the project page")]
    public async Task GivenINavigateToTheProjectPage()
    {
        await _homePage.GoToProjectPage();
    }
  
    [When(@"I pick task '(.*)'")]
    public async Task WhenIPickTask(TaskEnum task)
    {
        await _projectPage.ElementVisible();
        await _projectPage.PickTask(task);
    }
    
    [Then(@"I upload image of dinosaurus with name '(.*)' and check results")]
    public async Task ThenIUploadImageOfDinosaurusWithNameAndCheckResults(DinosaurusEnum dinosaurusName)
    {
        await _projectPage.UploadImage(dinosaurusName);
        await _projectPage.CheckResult(dinosaurusName);
    }
    
}