using EvaluationServices.BusinessLayer.UseCases;
using EvaluationServices.BusinessLayer.UseCases.AssitantRole;
using EvaluationServices.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.Interfaces;
using RegistrationServices.BusinessLayer.UseCase.Assistant;
using RegistrationServices.DataLayer;

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
            services.AddLogging();
            RegistrationConfigureServices(services);
            EvaluationConfigureServices(services);
        }
        public void RegistrationConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RegistrationContext>((options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegistrationServicesDB;Trusted_Connection=True;")));
            services.AddScoped<IRSUnitOfWork, RSUnitOfWork>();
            services.AddScoped<IRSAssistantRole, RSAssistantRole>();
            services.AddScoped(x=> TestHelper.MockIRSServiceRole());
        }
        public void EvaluationConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<EvaluationContext>((options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EvaluationDB;Trusted_Connection=True;")));
            services.AddScoped<IESUnitOfWork, ESUnitOfWork>();
            services.AddScoped<IESAttendeeRole, ESAttendeeRole>();
            services.AddScoped<IESAssistantRole, ESAssistantRole>();
        }


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
