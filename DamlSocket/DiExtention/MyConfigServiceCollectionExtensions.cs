using System.Reflection;
using DamlSocket.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DamlSocket.DiExtention
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
            this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddDamlSocket(
            this IServiceCollection services, int port = 4649)
        {
            ListenerStartup.Port = port;
            services.AddSingleton<CreateSession>();
            services.AddSingleton<ListenerStartup>();
            services.AddScoped<Client>();

            return services;
        }
    }
}