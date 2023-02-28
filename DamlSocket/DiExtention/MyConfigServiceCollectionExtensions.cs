using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkerServiceSuperSocket.Services;

namespace WorkerServiceSuperSocket.DiExtention
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
            this IServiceCollection services, IConfiguration config)
        {
        

            return services;
        }

        public static IServiceCollection AddDamlSocket(
            this IServiceCollection services)
        {
            services.AddSingleton<CreateSession>();
            services.AddSingleton<ListenerStartup>();

            services.AddScoped<Client>();

            return services;
        }
    }
}

