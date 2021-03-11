using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastracture.Identity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Web.Configurations;

namespace Web
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddCommandLine(args)
                            .Build();
            var host = CreateHostBuilder(args).Build();

            Log.Logger = LoggerSetup.CreateLogger(config);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            try
                {

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await Infrastracture.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await Infrastracture.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                    await Infrastracture.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);

                    Log.Information("Starting up");
                    CreateHostBuilder(args).Build().Run();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Application start-up failed");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
