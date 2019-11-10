using AutoMapper;
using FluentValidation.AspNetCore;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace HAS.MyPractice.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;

            var testConfig = Configuration["MPY:Version"];

            Environment = env;
        }

        public IHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                services.AddMiniProfiler();
            }
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient();
            
            services.AddHttpClient(HASClientFactories.LIBRARY, client =>
            {
                client.BaseAddress = new Uri(Configuration["MPY:API:Library:Authority"]);
            });

            services.AddHttpClient(HASClientFactories.MEDIA, client =>
            {
                client.BaseAddress = new Uri(Configuration["MPY:API:Media:Authority"]);
            });

            services.AddHttpClient(HASClientFactories.PROFILE, client =>
            {
                client.BaseAddress = new Uri(Configuration["MPY:API:Profile:Authority"]);
            });

            services.AddHttpClient(HASClientFactories.TRIBE, client =>
            {
                client.BaseAddress = new Uri(Configuration["MPY:API:Tribe:Authority"]);
            });

            services.AddHttpClient(HASClientFactories.IDENTITY, client =>
            {
                client.BaseAddress = new Uri(Configuration["MPY:IdentityServer:Authority"]);
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddHASIdentityService(Configuration, Environment);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("student", policyAdmin => policyAdmin.RequireClaim("role", "student"));
                options.AddPolicy("instructor", policyAdmin => policyAdmin.RequireClaim("role", "instructor"));
                options.AddPolicy("admin", policyAdmin => policyAdmin.RequireClaim("role", "admin"));
                options.AddPolicy("superadmin", policyAdmin => policyAdmin.RequireClaim("role", "superadmin"));
            });
            
            services.AddHttpContextAccessor();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.Name = Configuration["MPY:Cookies:Session:Name"];
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", "admin");
                options.Conventions.AuthorizeFolder("/Instructor", "instructor");
            }).AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // app.UseMiniProfiler();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMPYProfile();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
