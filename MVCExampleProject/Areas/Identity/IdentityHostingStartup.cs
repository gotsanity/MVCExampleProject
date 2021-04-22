using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCExampleProject.Areas.Identity.Data;
using MVCExampleProject.Data;

[assembly: HostingStartup(typeof(MVCExampleProject.Areas.Identity.IdentityHostingStartup))]
namespace MVCExampleProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddAuthorization(options =>
                {
                    //options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role"));
                    options.AddPolicy("ColorPref", policy => policy.RequireClaim("FavColor", "Green", "Red"));
                });

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddClaimsPrincipalFactory<AppClaimsFactory>();
            });
        }
    }
}