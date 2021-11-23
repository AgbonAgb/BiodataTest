using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiodataTest.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BiodataTest.Services;
using BiodataTest.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Google;

namespace BiodataTest
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

            //To authorize all controllers
            services.AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter()));
            //services.AddControllersWithViews();//Authorize controllers o =>o.Filters.Add(new AuthorizeFilter())
            //services.AddRazorPages().AddMvcOptions(o => o.Filters.Add(new AuthorizeFilter()));//authorize all pages
            var connection = Configuration.GetConnectionString("Cnn");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IBiodata, BiodataServices>();
            services.AddScoped<IUserRepository, UserRepositoryServices>();
            services.AddScoped<IDept, DeptServices>();
            services.AddAutoMapper();
            //using Coogies//;//we could add this o => o.LoginPath="account/signin. Stop at .AddCookie(); if no external authentication required
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            services.AddAuthentication(o => {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //this will challenge user to google login page if not authenticated and want to bypass
               // o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddCookie(ExternalAuthenticationDefaults.AuthenticationScheme)
                .AddGoogle(o =>
                {
                    o.SignInScheme = ExternalAuthenticationDefaults.AuthenticationScheme;
                    o.ClientId = Configuration["Google:ClientId"];
                    o.ClientSecret = Configuration["Google:ClientSecret"];
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                 context.Database.Migrate();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            if (env.IsProduction())
            {
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();//added for authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
