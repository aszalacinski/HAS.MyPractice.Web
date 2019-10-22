using HAS.MyPractice.ApplicationServices.Alerts;
using HAS.MyPractice.ApplicationServices.IdentityServer;
using HAS.MyPractice.Library;
using HAS.MyPractice.Media;
using HAS.MyPractice.Profile;
using HAS.MyPractice.Tribe;
using HAS.MyPractice.UseCase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
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
            }


            services.AddHttpClient();


            services.AddHttpClient<ILibraryService, LibraryService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("MPY:API.Library:Authority").Value);
            });

            services.AddHttpClient<IMediaService, MediaService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("MPY:API.Media:Authority").Value);
            });

            services.AddHttpClient<IProfileService, ProfileService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("MPY:API.Profile:Authority").Value);
            });

            services.AddHttpClient<ITribeService, TribeService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("MPY:API.Tribe:Authority").Value);
            });

            services.AddHttpClient<IIdentityServerService, IdentityServerService>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection("MPY:IdentityServer:Authority").Value);
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
            services.AddSingleton<IDataProtectionService, DataProtectionService>();
            services.AddTransient<IAlertService, AlertService>();
            services.AddTransient<Convert_Student_Account_to_Instructor_Account>();
            services.AddTransient<Rollback_Student_Account_to_Instructor_Account>();
            services.AddTransient<Move_Media_To_Instructor_Default_Folder>();
            services.AddTransient<List_All_Media_In_Library>();

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", "admin");
                options.Conventions.AuthorizeFolder("/Upload", "instructor");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
