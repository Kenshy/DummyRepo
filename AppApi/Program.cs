using System;
using System.Threading.Tasks;
using AppApi.Extensions.DataSeed;
using Data1;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var seedTask = SeedData.EnsureSeedData(host.Services);
            seedTask.Wait();

            host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<PersonalityContext>().Database.Migrate();

                var appDataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
                Console.WriteLine("Seeding database...");

                await appDataInitializer.Seed();
                Console.WriteLine("Done seeding database.");
            }
        }
    }
}
