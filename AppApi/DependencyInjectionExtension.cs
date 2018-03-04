using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Contracts;
using Services.Options;

namespace AppApi
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection DependencyInjectionRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPersonalityService, PersonalityService>();
            services.AddTransient<ITonalityService, TonalityService>();

            services.Configure<PersonalityOption>(configuration.GetSection("Personality"));
            services.Configure<TonalityOption>(configuration.GetSection("Tonality"));

            return services;
        }
    }
}
