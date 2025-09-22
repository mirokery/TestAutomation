
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using TestAutomation.APITests.Client;
using TestAutomation.UITests.Common.Helpers;

namespace TestAutomation.APITests.Tests.StepDefinitions;

[Binding]
public class APISteps
{
    private string _imagePath;
    private  RestResponse _response;
    
    [Given(@"I have a image of dinosaurus '(.*)'")]
    public async Task IHaveAImageOfDinosaurus(DinosaurusEnum dinosaurusName)
    {
        _imagePath = $@"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Inputs\{dinosaurusName.ToString()}.JPG"; 
        
    }
    
    [When(@"I call API '(.*)'")]
    public async Task ICallAPI(TaskEnum taskEnum)
    {   
        var client = new ApiClient();
        _response = await client.Classification(_imagePath);
        
    }
    
    
    [Then(@"I got response '(.*)'")]
    public async Task IGotResponse(DinosaurusEnum dinosaurusName)
    {   
        _response.Content.Should().Contain(dinosaurusName.ToString());
        
    }
    
}