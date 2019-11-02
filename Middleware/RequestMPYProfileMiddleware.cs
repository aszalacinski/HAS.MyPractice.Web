using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
                        //var token = await idservice.GetAccessToken(clientId, clientSecret, scopes);
                        var token = await mediator.Send(new GetAccessTokenCommand(clientId, clientSecret, scopes));

                        // get the userid from the User sub claim
                        string userId = context.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;

                        //var profile = await profileService.GetProfileByUserId(userId, token);
                        var profile = await mediator.Send(new GetProfileByUserIdQuery(userId, token));

                        // save profile details to cookie
                        // we are deserializing and then serializing JUST to make sure json is proper

                        var json = JsonSerializer.Serialize(profile, DefaultJsonSettings.Settings);

                        // encrypt the profile object
                        //var mpyProfile = dataProtectionService.EncryptProfileCookie(json);
                        var mpyProfile = await mediator.Send(new DataProtectionEncryptCommand(json));

                        // create the cookie.
                        context.Response.Cookies.Append(cookieName, mpyProfile);

                        await _next(context);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    // if profile is already saved, move on... 
                    // only way updated NEW MPY Profile details are captured is if user logs out and logs back in
                    // continue on...
                    await _next(context);
                }
            }
            else
            {
                // user isn't logged in... clean up to be safe...
                context.Response.Cookies.Delete(cookieName);
                await _next(context);
            }
        }
    }
}
