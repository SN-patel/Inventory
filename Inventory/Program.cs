using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.Context.Models;
using Serilog;

namespace Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                         .Enrich.FromLogContext()
                         .WriteTo.File("log//inventory-log.txt", rollingInterval: RollingInterval.Day)
                         .CreateLogger();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<InventoryContext>();

                SetUpInitialData(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void SetUpInitialData(InventoryContext context)
        {
            var cat = new Category()
            {
                Type = "Clothing"
            };
            context.Add(cat);
            context.SaveChanges();

            var p1 = new Product()
            {
                Name = "Denim Jeans",
                Type = "Pant",
                Price = 100M,
                Category = cat
            };
            var p2 = new Product()
            {
                Name = "Polo T-shirt",
                Type = "Shirt",
                Price = 100M,
                Category = cat
            };
            var p3 = new Product()
            {
                Name = "Hoodi",
                Type = "sweater",
                Price = 100M,
                Category = cat
            };

            context.Add(p1);
            context.Add(p2);
            context.Add(p3);
            context.SaveChanges();

        }
    }
}
