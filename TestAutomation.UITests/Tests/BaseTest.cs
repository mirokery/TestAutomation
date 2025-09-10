using OpenQA.Selenium;
using TestAutomation.UITests.Common.Fixtures;
using TestAutomation.UITests.Common.Helpers;
using TestAutomation.UITests.Common.Pages;

namespace TestAutomation.UITests.Common.Tests;

[TestFixture]
public class BaseTest:BrowserFixture
{
    [Test]
    public async Task ClassifyTest()
    {   
        var driver = Driver;
        
        await Classify(driver,DinosaurusEnum.trex);
        await Classify(driver,DinosaurusEnum.stego);
        await Classify(driver,DinosaurusEnum.velo);
        await Classify(driver,DinosaurusEnum.para);
        await Classify(driver,DinosaurusEnum.spino);

    }
    
    public async Task Classify(IWebDriver driver, DinosaurusEnum dinosaurusName)
    {
        
        var homePage = new HomePage(driver);
        var projectPage = new ProjectPage(driver);
        
        await homePage.GoToProjectPage();

        await projectPage.ElementVisible();
        await projectPage.PickTask(TaskEnum.classify);
        await projectPage.UploadImage(dinosaurusName);
        await projectPage.CheckResult(dinosaurusName);

        await projectPage.GoToHomePage();
    }
}

