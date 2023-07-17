using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.interfaces;
using NuGet.Configuration;
using System.Configuration;

namespace Shop
{
    public class Startup { 
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IDeviceRepository, DeviceRepository>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Properties/appsettings.json")
                .Build();

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = configuration.GetSection("MongoConnection:Database").Value;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { 
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) => {
                await context.Response.WriteAsync("Hello");
            });
        }
    }
}