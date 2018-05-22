using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prointer.Services.API.Data;
using Prointer.Services.API.Models;

namespace Prointer.Services.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            
            var contentRoot = Directory.GetCurrentDirectory();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {

                    var context = services.GetRequiredService<AppDbContext>();
                    //Configurations.Initialize(context);

                    var config = new ConfigurationBuilder()
                    .SetBasePath(contentRoot)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                    //// Requires using RazorPagesMovie.Models;                    
                    //// apply migration
                    // SampleDataProvider.ApplyMigration(services);

                    //// seed default data                    
                    SampleDataProvider.Seed(services, config);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }


}
