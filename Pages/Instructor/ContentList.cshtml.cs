using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAS.MyPractice.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class IndexModel : PageModel
    {

        public IEnumerable<Media> Media { get; set; }
        public IEnumerable<Media> DefaultMedia { get; set; }
        public void OnGet()
        {

        }
    }
}