using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationServices.BusinessLayer.UseCases;
using EvaluationServices.DataLayer;
using FacilityServices.BusinessLayer.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.FacilityServices.Interfaces;

namespace OnlineServices.WebUx.Mvc6
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // MustKnow Logging Step 1: Log configuration avec SERILOG
            services.AddLogging();

            // ConfigureEvaluationServices(services);
        }

        //public void ConfigureEvaluationServices(IServiceCollection services)
        //{
        //    //  services.AddTransient<IESUnitOfWork, ESUnitOfWork>();
        //    //  services.AddTransient<IESAttendeeRole, ESAttendeeRole>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // MustKnow Logging Step 2: Add ILoggerFactory à la liste de parametres pour configure SERILOG
      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
                endpoints.MapControllerRoute(
                    name: "defaultAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
