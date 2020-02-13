using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class DashboardModel : PageModel
    {
        private readonly IMediator _mediator;

        public string StudentName { get; private set; }

        public DashboardModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {
            Model.Profile profile = JsonSerializer.Deserialize<Model.Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);
            StudentName = profile.PersonalDetails.FirstName;
        }
    }
}