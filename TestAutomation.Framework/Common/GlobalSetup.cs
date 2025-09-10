using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace TestAutomation.Framework.Common;

public static class GlobalSetup
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration => 
        _configuration ??= BuildConfiguration();

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory) 
            .AddJsonFile("appsettings.json")
            .AddYamlFile("Configurations/localhost.yaml") 
            .AddEnvironmentVariables()
            .Build();
    }
}