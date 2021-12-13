using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.AspNetCore.Mappers;

namespace AutoMapper.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddObjectMapper(this IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>(sp => new MapperConfiguration(config =>
            {
                config.AddProfile(typeof(UserMapperProfile));
            }));

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            return services;
        }
    }
}
