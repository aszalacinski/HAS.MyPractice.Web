using Microsoft.AspNetCore.Builder;

namespace HAS.MyPractice
{
    public static class RequestMPYProfileMiddlewareExtensions
    {
        public static IApplicationBuilder UseMPYProfile(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMPYProfileMiddleware>();
        }
    }
}
