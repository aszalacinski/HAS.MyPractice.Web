using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using static HAS.MyPractice.DataProtection.DataProtectionDecrypt;

namespace HAS.MyPractice.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string _cookieName;
        private readonly IMediator _mediator;

        public IndexModel(IConfiguration configuration, IMediator mediator)
        {
            _cookieName = configuration["MPY:Cookies:ProfileMiddleware:Name"];
            _mediator = mediator;
        }

        public string Token { get; set; }
        public string Id { get; set; }
        public string CookieOutput { get; set; }

        public string TestSecret { get; set; }

        public async Task OnGet()
        {
            Token = await HttpContext.GetTokenAsync("access_token");

            var cookie = HttpContext.Request.Cookies[_cookieName];

            if (cookie != null)
            {
                CookieOutput = await _mediator.Send(new DataProtectDecryptCommand(cookie));
            }


        }

    }
}
