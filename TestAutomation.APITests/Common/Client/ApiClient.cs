using RestSharp;
using TestAutomation.Framework.Configurations;

namespace TestAutomation.APITests.Client;

public class ApiClient
{
    
    private readonly string _baseUrl;

    public ApiClient()
    {
        _baseUrl = Framework.Common.GlobalSetup.Configuration[ConfigurationVariables.ApiUrl];
    }
    public async Task<RestResponse> GetHealthAsync()
    {
        var client = new RestClient(_baseUrl);
        var request = new RestRequest("/health", Method.Get);
        return await client.ExecuteAsync(request);
    }
    
    public async Task<RestResponse> Classification(string filePath)
    {
        var client = new RestClient(_baseUrl);
        var request = new RestRequest("/dinosaurus/classification", Method.Post);
        request.AddFile("image", filePath);
        
        return await client.ExecuteAsync(request);
    }
    
    public async Task<byte[]> Detection(string filePath)
    {
        var client = new RestClient(_baseUrl);
        var request = new RestRequest("/dinosaurus/detection", Method.Post);
        request.AddFile("image", filePath);
        
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"API call failed: {response.StatusCode} - {response.Content}");

        return response.RawBytes; 
    }
    public async Task<byte[]> Segmentation(string filePath)
    {
        var client = new RestClient(_baseUrl);
        var request = new RestRequest("/dinosaurus/segmentation", Method.Post);
        request.AddFile("image", filePath);
        
        var response = await client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new Exception($"API call failed: {response.StatusCode} - {response.Content}");
        
        return response.RawBytes; 
    }
    public void SaveImage(byte[] imageBytes, string savePath)
    {
        File.WriteAllBytes(savePath, imageBytes);
    }
}



