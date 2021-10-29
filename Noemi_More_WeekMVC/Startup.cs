using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Noemi_More_WeekMVC.Core.BusinessLayer;
using Noemi_More_WeekMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC
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

            //services.AddTransient<ICounterService, CounterService>();


            services.AddScoped<IBusinessLayer, MainBusinessLayer>();

            services.AddScoped<IMenu1Repository, RepositoryMenuEF>();
            services.AddScoped<IPiattiRepository, RepositoryPiattiEF>();
            services.AddScoped<IUtentiRepository, RepositoryUtentiEF>();


            services.AddDbContext<MasterContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EFConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Adm", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });



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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
