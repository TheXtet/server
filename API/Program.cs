using System;
using System.Net;
using Grains;
using Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseOrleans(builder =>
                {
                    builder
                        .UseLocalhostClustering()
                        .AddCosmosDBGrainStorageAsDefault(options =>
                        {
                            options.ConnectionMode = ConnectionMode.Direct;
                            options.AccountEndpoint = "https://xtet.documents.azure.com:443/";
                                                              
                            // TODO: Insert key
                            options.AccountKey = "";
                            options.DB = "DatabaseName";

                            // options.Collection = "Users";
                            // options.DropDatabaseOnInit = true; // Comment it
                            options.CanCreateResources = true;
                        })
                        .Configure<HostOptions>(options => options.ShutdownTimeout = TimeSpan.FromMinutes(1))
                        .Configure<ClusterOptions>(opts =>
                        {
                            opts.ClusterId = "dev";
                            opts.ServiceId = "MyAPI";
                        })
                        .Configure<EndpointOptions>(opts =>
                        {
                            opts.AdvertisedIPAddress = IPAddress.Loopback;
                        })
                        .ConfigureApplicationParts(parts =>
                        {
                            parts.AddApplicationPart(typeof(UsersGrain).Assembly).WithReferences();
                            parts.AddApplicationPart(typeof(CriteriaGrain).Assembly).WithReferences();
                            parts.AddApplicationPart(typeof(IFormula).Assembly).WithReferences();
                            parts.AddApplicationPart(typeof(ICriteria).Assembly).WithReferences();
                        });
                })
               .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}