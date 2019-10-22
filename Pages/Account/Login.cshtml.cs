using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Account
{
    [Authorize]
    public class LoginModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/");
        }
    }
}