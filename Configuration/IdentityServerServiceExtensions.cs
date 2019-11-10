using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HAS.MyPractice
{
    public static class IdentityServerServiceExtensions
    {
        public static IServiceCollection AddHASIdentityService(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                    options.Cookie.Name = "mpy.web.autorefresh";
                })
                .AddAutomaticTokenManagement()
                .AddOpenIdConnect("oidc", options =>
                {
                    var clientId = configuration.GetSection("MPY:IdentityServer:WebApp:ClientId").Value;
                    if (string.IsNullOrEmpty(clientId))
                    {
                        throw new ArgumentNullException("Client Id must be specified");
                    }
                    var clientSecret = configuration.GetSection("MPY:IdentityServer:WebApp:ClientSecret").Value;
                    if (string.IsNullOrEmpty(clientSecret))
                    {
                        throw new ArgumentNullException("Client Secret must be specified");
                    }

                    options.SignInScheme = "Cookies";

                    options.Authority = configuration.GetSection("MPY:IdentityServer:Authority").Value;

                    if (env.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }

                    options.ClientId = clientId;
                    // matches the secret defined in the IDServer Client for mvcHybrid
                    options.ClientSecret = clientSecret;
                    // this basically means "use hybrid flow"
                    options.ResponseType = "code id_token";


                    // add these scopes
                    // the api we want to access
                    options.Scope.Clear();
                    options.Scope.Add("MPY.Profile");
                    options.Scope.Add("MPY.Content");
                    options.Scope.Add("openid");
                    // indicates refresh tokens are allowed
                    options.Scope.Add("offline_access");

                    //options.ClaimActions.MapAllExcept("iss", "nbf", "exp", "aud", "nonce", "iat", "c_hash");

                    // this keeps the role claim in our client identity
                    options.ClaimActions.MapJsonKey("role", "role");

                    // saves all the tokens; identity, access and refresh
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });


            return services;
        }
    }
}
