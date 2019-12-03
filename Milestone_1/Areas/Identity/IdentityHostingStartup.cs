using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Milestone_1.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Milestone_1.Areas.Identity.IdentityHostingStartup))]
namespace Milestone_1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Milestone_1IdentityDbContext>(options =>
                {
                    options.UseSqlite("Filename=identity.db");
                });

    
                    services.AddDefaultIdentity<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<Milestone_1IdentityDbContext>();

                

            });





        }
    }
}