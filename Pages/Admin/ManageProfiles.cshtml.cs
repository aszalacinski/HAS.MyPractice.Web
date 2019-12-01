using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetInstructorProfiles;
using static HAS.MyPractice.GetStudentProfiles;
using static HAS.MyPractice.ProvisionAsInstructor;
using static HAS.MyPractice.ProvisionAsStudent;
using static HAS.MyPractice.Web.Features.Alert.ThrowAlert;

namespace HAS.MyPractice.Web.Pages.Admin
{
    public class ManageProfilesModel : PageModel
    {
        private readonly IMediator _mediator;

        public ManageProfilesModel(IMediator mediator) => _mediator = mediator;

        [BindProperty]
        public QueryResult Data { get; set; }

        public class QueryResult
        {
            public IEnumerable<Profile> Members { get; set; }
        }

        public async Task OnGetAsync(string t)
        {
            IEnumerable<Profile> members = null;

            if (!string.IsNullOrEmpty(t) && t.ToLower().Equals("student".ToLower()))
            {
                members = await _mediator.Send(new GetStudentProfilesQuery());
            }
            else
            {
                members = await _mediator.Send(new GetInstructorProfilesQuery());
            }

            Data = new QueryResult { Members = members };
        }

        public async Task<IActionResult> OnPostToInstructorAsync(string profileId)
        {
            try
            {
                var convert = await _mediator.Send(new ProvisionAsInstructorCommand(profileId));
            }
            catch(InstructorPublicNameException ex)
            {
                await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, $"Invalid Public Name for Instructor", ex.Message));
                return RedirectToPage("ManageProfiles", new { t = "student" });
            }
            return RedirectToPage("ManageProfiles", new { t = "instructor" });
        }

        public async Task<IActionResult> OnPostToStudentAsync(string profileId)
        {
            var convert = await _mediator.Send(new ProvisionAsStudentCommand(profileId));
            return RedirectToPage("ManageProfiles", new { t = "student" });
        }
    }
}