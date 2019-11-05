using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetMediaById;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator) => _mediator = mediator;

        public string MediaId { get; set; }

        public async Task OnGetAsync(string c)
        {
            MediaId = c;

            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName));

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            Media media = await _mediator.Send(new GetMediaByIdQuery(c));

        }
    }
}