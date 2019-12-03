using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Milestone_1.Abstractions;
using Milestone_1.Data;
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

            services.AddDbContext<TwitterContext>(options =>
            {
                options.UseSqlite("Filename=mytwitter.db");
            });
            services.AddMvc();
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
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthentication();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{controller=Login}/{action=Index}/{id?}");

            //    routes.MapRoute(
            //    name: "home",
            //    template: "{controller=Home}/{action=Home}/{id?}");


            //});
            app.UseMvcWithDefaultRoute();


            
        }
    }
}
