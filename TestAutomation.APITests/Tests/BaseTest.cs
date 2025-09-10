using FluentAssertions;
using TestAutomation.APITests.Common.Fixtures;
using TestAutomation.UITests.Common.Helpers;

namespace TestAutomation.APITests.Tests;

[TestFixture]
public class BaseTest: ApiFixture
{
    DinosaurusEnum  dinosaurusName = DinosaurusEnum.stego;
    
    [Test]
    public async Task HealthCheck()
    {
        var response = await  Client.GetHealthAsync();

        response.Content.Should().Contain("ok");
        response.IsSuccessful.Should().BeTrue();
    }
    
    [Test]
    public async Task Classification()
    {   
        
        string imagePath = $@"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Inputs\{dinosaurusName.ToString()}.JPG"; 
        var response = await Client.Classification(imagePath);

        
        response.Content.Should().Contain(dinosaurusName.ToString());
        
    }
    
    [Test]
    public async Task Detection()
    {
        string imagePath = $@"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Inputs\{dinosaurusName.ToString()}.JPG"; 
        
        string outputImagePath = @"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Outputs\detection.jpg";

        byte[] returnedImage = await Client.Detection(imagePath);

        Client.SaveImage(returnedImage, outputImagePath);
        
    }
    
    [Test]
    public async Task Segmentation()
    {
        string imagePath =$@"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Inputs\{dinosaurusName.ToString()}.JPG"; 
        
        string outputImagePath = @"C:\Users\miro\RiderProjects\TestAutomation\TestAutomation.Framework\Resources\Outputs\segmentation.jpg";

        byte[] returnedImage = await Client.Segmentation(imagePath);

        Client.SaveImage(returnedImage, outputImagePath);
        
    }
}



