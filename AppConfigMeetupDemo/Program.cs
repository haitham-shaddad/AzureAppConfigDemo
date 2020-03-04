using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppConfigMeetupDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var existingConfig = config.Build();
                    config.AddAzureAppConfiguration(azConfig =>
                    {
                        azConfig.ConfigureRefresh(refresh =>
                        {
                            refresh.Register("appsettings:AppTitle", true);
                            refresh.SetCacheExpiration(TimeSpan.FromSeconds(5));
                        });
                        azConfig.Select(KeyFilter.Any, hostingContext.HostingEnvironment.EnvironmentName);
                        azConfig.UseFeatureFlags();
                        //This connects using the connection string, you can use this anywhere (Azure, AWS, OnPremise ...)
                        azConfig.Connect(existingConfig["AzureAppConfig:ConnectionString"]);

                        //This one only works if your application is running on Azure and the service has an identity and the identity has read access to the App Config Instance via Access Control (IAM)
                        //azConfig.Connect(new Uri(existingConfig["AzureAppConfig:EndPointUri"]), new ManagedIdentityCredential());

                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
