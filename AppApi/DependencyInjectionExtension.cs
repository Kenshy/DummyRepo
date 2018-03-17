﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Contracts;
using Services.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AppApi
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection DependencyInjectionRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IPersonalityService, PersonalityService>();
            services.AddTransient<ITonalityService, TonalityService>();

            services.Configure<PersonalityOption>(configuration.GetSection("Personality"));
            services.Configure<TonalityOption>(configuration.GetSection("Tonality"));

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            return services;
        }
}
}
