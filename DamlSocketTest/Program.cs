using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerServiceSuperSocket.DiExtention;
using WorkerServiceSuperSocket.Services;

namespace WorkerServiceTest
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
                    services.AddHostedService<Worker>();
                });
    }
}