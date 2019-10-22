using HAS.MyPractice.ApplicationServices.IdentityServer;
using HAS.MyPractice.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class RequestMPYProfileMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestMPYProfileMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration, IIdentityServerService idservice, IProfileService profileService, IDataProtectionService dataProtectionService)
        {
            string cookieName = configuration.GetSection("MPY:Cookies:ProfileMiddleware:Name").Value;

            var clientId = configuration.GetSection("MPY:IdentityServer:ProfileMiddleware:ClientId").Value;
            var clientSecret = configuration.GetSection("MPY:IdentityServer:ProfileMiddleware:ClientSecret").Value;
            var scopes = configuration.GetSection("MPY:IdentityServer:ProfileMiddleware:Scopes").Value;

            // check if user is logged in... 
            if (context.User.Identity.IsAuthenticated)
            {
                if (context.Request.Cookies[cookieName] == null)
                {
                    try
                    {
                        // get token
                        var token = await idservice.GetAccessToken(clientId, clientSecret, scopes);

                        // get the userid from the User sub claim
                        string userId = context.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;

                        var profile = await profileService.GetProfileByUserId(userId, token);

                        // save profile details to cookie
                        // we are deserializing and then serializing JUST to make sure json is proper

                        var json = JsonConvert.SerializeObject(profile);

                        // encrypt the profile object
                        var mpyProfile = dataProtectionService.EncryptProfileCookie(json);

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
