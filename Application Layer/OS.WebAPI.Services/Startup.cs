using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceServices.BusinessLayer.UseCases;
using AttendanceServices.DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineServices.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices;
using OnlineServices.Common.RegistrationServices;
using OS.WebAPI.Services.Mocks;

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
            services.AddControllers();

            InjectRegistrationServicesDependencies(services);
            InjectAttendanceServicesDependencies(services);
        }

        private static void InjectRegistrationServicesDependencies(IServiceCollection services)
        {
            //Mocks to implement...
            services.AddTransient<IRSServiceRole>(x => RegistrationServicesMockHelper.RSServiceRoleObject());

            //Implementations
            //...
        }

        private static void InjectAttendanceServicesDependencies(IServiceCollection services)
        {
            //Mocks to implement...
            services.AddTransient<IPresenceRepository>(x => AttendenceServicesMockHelper.PresenceRepositoryObject());
            
            //Implementations
            services.AddTransient<IASAttendeeRole, ASAttendeeRole > ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
