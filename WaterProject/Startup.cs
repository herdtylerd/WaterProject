using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        

        // Insert the following lines to set up database
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Use mvc pattern

            services.AddDbContext<WaterProjectContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:WaterDBConnection"]);
           });

            // Add this
            services.AddScoped<IWaterProjectRepository, EFWaterProjectRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Corresponds to wwwroot
            app.UseStaticFiles();
            app.UseSession(); // Add this line

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Add this (first ones are in shortened version): 
                endpoints.MapControllerRoute("typepage", "{projectType}/Page{pageNum}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                name: "Paging",
                pattern: "Page{pageNum}",
                defaults: new { Controller = "Home", action = "Index", pageNum = 1});

                endpoints.MapControllerRoute("type", "{projectType}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapDefaultControllerRoute(); // Orgininally here

                endpoints.MapRazorPages();
            });
        }
    }
}
