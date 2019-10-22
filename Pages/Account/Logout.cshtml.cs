using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Account
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            return SignOut("Cookies", "oidc");
        }

    }
}