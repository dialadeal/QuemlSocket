using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DamlSocket.DiExtention;
using DamlSocketTest.Services;
using HazmunaService.Ivrs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DamlSocketTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDamlSocket();
                    services.AddScoped<FirstIvr>();
                    services.AddScoped<SecondIvr>();
                    services.AddScoped<WelcomeIvr>();
                    services.AddHostedService<Worker>();
                });
    }
}