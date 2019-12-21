using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Authorization;
using Milestone_1.Abstractions;
using Milestone_1.Data;
using Milestone_1.Hubs;
using Milestone_1.models;
using Milestone_1.Services;
namespace Milestone_1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //Session end
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //SignalR
            services.AddSignalR();
            //SignalR
            services.AddDbContext<TwitterContext>(options =>
            {
                options.UseSqlite("Filename=mytwitter.db");
            });
            services.AddScoped<UserDataService>();
            services.AddScoped<IAllRepo, Repo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            //Session
            app.UseSession();
            //Session end
            app.UseAuthentication();

            //SignalR
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
            //SignalR


            //SignalR
            app.UseMvcWithDefaultRoute();
            app.UseCookiePolicy();
        }
    }
}
