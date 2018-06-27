using System.Reflection;
using AppApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Services.Mappings;
using Microsoft.EntityFrameworkCore;
using Data1;

namespace AppApi
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Environment = env;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Startup>()
                .Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PersonalityContext>(options => options.UseSqlServer(connection));
            services.AddAutoMapper(typeof(TargetMapperServices).GetTypeInfo().Assembly);
            services.DependencyInjectionRegistration(Configuration);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sentiment");
            });

            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    serviceScope.ServiceProvider.GetService<PersonalityContext>().EnsureSeed();
            //}

            app.UseMvc();
        }
    }
}
