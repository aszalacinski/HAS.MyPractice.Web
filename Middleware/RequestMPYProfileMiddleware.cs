using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static HAS.MyPractice.DataProtection.DataProtectionDecrypt;
using static HAS.MyPractice.DataProtection.DataProtectionEncrypt;
using static HAS.MyPractice.GetProfileByUserId;
using static HAS.MyPractice.IdentityServer.GetAccessToken;

namespace HAS.MyPractice
{
    public class RequestMPYProfileMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMPYProfileMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration, IMediator mediator)
        {
            string cookieName = configuration["MPY:Cookies:ProfileMiddleware:Name"];

            var clientId = configuration["MPY:IdentityServer:ProfileMiddleware:ClientId"];
            var clientSecret = configuration["MPY:IdentityServer:ProfileMiddleware:ClientSecret"];
            var scopes = configuration["MPY:IdentityServer:ProfileMiddleware:Scopes"];

            // check if user is logged in... 
            if (context.User.Identity.IsAuthenticated)
            {
                if (context.Request.Cookies[cookieName] == null)
                {
                    try
                    {
                        // get token
                        var token = await mediator.Send(new GetAccessTokenCommand(clientId, clientSecret, scopes));

                        // get the userid from the User sub claim
                        string userId = context.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;

                        var profile = await mediator.Send(new GetProfileByUserIdQuery(userId, token));

                        // save profile details to cookie
                        // we are deserializing and then serializing JUST to make sure json is proper
                        var json = JsonSerializer.Serialize(profile, DefaultJsonSettings.Settings);

                        // encrypt the profile object
                        var mpyProfile = await mediator.Send(new DataProtectionEncryptCommand(json));
                        
                        // create the cookie.
                        context.Response.Cookies.Append(cookieName, mpyProfile);

                        // set the session value
                        context.Session.SetString(HASSessionKeys.SessionKeyProfileName, json);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                // make sure session contains the profile details
                if (string.IsNullOrEmpty(context.Session.GetString(HASSessionKeys.SessionKeyProfileName)))
                {
                    // read the profile cookie and add string to session
                    var json = await mediator.Send(new DataProtectDecryptCommand(context.Request.Cookies[cookieName]));
                    context.Session.SetString(HASSessionKeys.SessionKeyProfileName, json);
                }

                // continue on...
                await _next(context);
            }
            else
            {
                // user isn't logged in... clean up to be safe...
                context.Response.Cookies.Delete(cookieName);
                context.Session.Clear();
                await _next(context);
            }
        }
    }
}
