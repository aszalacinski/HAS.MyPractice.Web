using HAS.MyPractice.Profile;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly string _cookieName;
        private readonly IProfileService _profileService;
        private readonly IDataProtectionService _dataProtectionService;

        public IndexModel(IConfiguration configuration, IProfileService profileService, IDataProtectionService dataProtectionService)
        {
            _configuration = configuration;
            _cookieName = _configuration.GetSection("MPY:Cookies:ProfileMiddleware:Name").Value;
            _profileService = profileService;
            _dataProtectionService = dataProtectionService;
        }

        public string Token { get; set; }
        public string Id { get; set; }

        public string CookieOutput { get; set; }

        public async Task OnGet()
        {
            Token = await HttpContext.GetTokenAsync("access_token");

            var cookie = HttpContext.Request.Cookies[_cookieName];

            if (cookie != null)
            {
                CookieOutput = _dataProtectionService.DecryptProfileCookie(cookie);
            }

        }

    }
}
