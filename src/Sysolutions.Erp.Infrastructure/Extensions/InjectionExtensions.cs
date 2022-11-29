using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using Sysolutions.Erp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;

namespace Sysolutions.Erp.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            //services.AddScoped<INotify, Notify>();

            /*var rabbitMqSection = configuration.GetSection("RabbitMq");
            var exchangeSection = configuration.GetSection("RabbitMqExchange");

            services.AddRabbitMqProducingClientTransient(rabbitMqSection)
                .AddProductionExchange("exchange.name", exchangeSection);*/

            return services;
        }
    }
}
