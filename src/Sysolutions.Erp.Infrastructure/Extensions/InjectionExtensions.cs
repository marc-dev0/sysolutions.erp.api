﻿using Sysolutions.Erp.Infrastructure.Persistences.Contexts;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Persistences.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<iCategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IMeasureRepository, MeasureRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStorageRepository, StorageRepository>();
            services.AddScoped<IEntryNoteRepository, EntryNoteRepository>();
            //services.AddScoped<INotify, Notify>();

            /*var rabbitMqSection = configuration.GetSection("RabbitMq");
            var exchangeSection = configuration.GetSection("RabbitMqExchange");

            services.AddRabbitMqProducingClientTransient(rabbitMqSection)
                .AddProductionExchange("exchange.name", exchangeSection);*/

            return services;
        }
    }
}
