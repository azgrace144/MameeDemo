// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData
{
    using AppOwnsData.DB;
    using AppOwnsData.Models;
    using AppOwnsData.Respositories;
    using AppOwnsData.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.IO;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var identities = Configuration["Grandfather:Father:Child"];

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            IConfiguration con = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddMvc();
            // Other service configurations
            // Register AadService and PbiEmbedService for dependency injection
            services.AddScoped(typeof(AadService))
                    .AddScoped(typeof(PbiEmbedService));

            services.AddDbContext<AppDbcontext>(conn => conn.UseSqlServer(Configuration.GetConnectionString("AZURESQL_CONNECTIONSTRING")));
            services.AddScoped<ILogin, AuthenticateLogin>();

            services.AddControllersWithViews();

            // Loading appsettings.json in C# Model classes
            services.Configure<AzureAd>(Configuration.GetSection("AzureAd"))
                    .Configure<PowerBI>(Configuration.GetSection("PowerBI"))
                    .AddSingleton(con);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Report}/{action=EmbedNewReport}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
