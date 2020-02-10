using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceServices.BusinessLayer.UseCases;
using AttendanceServices.DataLayer;
using AttendanceServices.DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineServices.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.RegistrationServices;
using OS.WebAPI.Services.Mocks;
using RegistrationServices.DataLayer;

namespace OS.WebAPI.Services
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
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();
            
            RegistrationServicesDependencyInjections(services);
            AttendanceServicesDependencyInjections(services);
        }

        private static void RegistrationServicesDependencyInjections(IServiceCollection services)
        {
            services.AddDbContext<RegistrationContext>(optionsBuilder =>
                optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegistrationDB;Trusted_Connection=True;")
                );

            //Mocks to implement...
            services.AddTransient<IRSServiceRole>(x => RegistrationServicesMockHelper.RSServiceRoleObject());
            services.AddTransient<IRSAttendeeRole>(x => RegistrationServicesMockHelper.RSAttendeeRoleObject());

            //Implementations
            //...
        }

        private static void AttendanceServicesDependencyInjections(IServiceCollection services)
        {
            //Mocks to implement...
            services.AddTransient<ICheckInRepository>(x => AttendenceServicesMockHelper.CheckInRepositoryObject());
            
            //Implementations
            //services.AddTransient<IASUnitOfWork, ASUnitOfWork>();
            services.AddTransient<IASAttendeeRole, ASAttendeeRole>();
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
                //app.UseExceptionHandler(appBuilder =>
                //{
                //    appBuilder.Run(async context =>
                //    {
                //        context.Response.StatusCode = 500;
                //        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                //    });
                //});
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
