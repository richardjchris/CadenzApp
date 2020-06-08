using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CadenzApp
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
            var Timeout = 120;
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.IsEssential = true;
                    //config.Cookie.HttpOnly = true;/*
                    //config.Cookie.SameSite = SameSiteMode.None;
                    config.Cookie.Name = "UserCookie";
                    config.LoginPath = "/Home/Login";
                    config.LogoutPath = "/Home/Logout";
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(Timeout);
                });

            /* services.Configure<CookiePolicyOptions>(options =>
             {
                 // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                 options.CheckConsentNeeded = context => false;
                 options.MinimumSameSitePolicy = SameSiteMode.None;
             });*/

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(Timeout);
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
            });

            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
            });
            services.AddHttpContextAccessor();
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");*/
            });
        }
    }
}
