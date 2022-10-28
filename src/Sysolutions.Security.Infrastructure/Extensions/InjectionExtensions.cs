using Sysolutions.Security.Infrastructure.Persistences.Contexts;
using Sysolutions.Security.Infrastructure.Persistences.Interfaces;
using Sysolutions.Security.Infrastructure.Persistences.Repositories;
using Sysolutions.Security.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Sysolutions.Security.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<INotify, Notify>();

            /*var rabbitMqSection = configuration.GetSection("RabbitMq");
            var exchangeSection = configuration.GetSection("RabbitMqExchange");

            services.AddRabbitMqProducingClientTransient(rabbitMqSection)
                .AddProductionExchange("exchange.name", exchangeSection);*/

            return services;
        }
    }
}
