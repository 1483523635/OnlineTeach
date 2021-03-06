﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTeach.Web.Data;
using OnlineTeach.Web.Models;
using OnlineTeach.Web.Services;
using OnlineTeach.Web.Domains.Repositories;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Domains.Teachers;
using OnlineTeach.Web.Domains.Cources;
using OnlineTeach.Web.StartupExt;

namespace OnlineTeach.Web
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

            services.AddDbContext<AdultDbContext>(options =>
            {
                options.UseInMemoryDatabase("adult");
                //options.UseSqlServer(Configuration.GetConnectionString("AdultDbStr"));
            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("Identity");
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;

                //sign out 
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                //sign in 
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.ConfigureApplicationCookie(config =>
            {
                //config.Cookie.Domain = "*.naisi.com";
                config.Cookie.HttpOnly = true;
                config.Cookie.Name = "naisiCookie";

                config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                config.LoginPath = "/Account/Login";
                config.LogoutPath = "/Account/Logout";
                config.SlidingExpiration = true;

            });
            services.AddMvc();
            //配置管理员账户
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireUserName("1483523635@qq.com"));
            });
            //仓储服务泛型注入
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<TeachersManager, TeachersManager>();
            services.AddScoped<CourcesManager, CourcesManager>();
            services.MapperInit();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("AuthMessageSenderOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
