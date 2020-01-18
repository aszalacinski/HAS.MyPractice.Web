using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Admin
{
    public class InviteInstructorModel : PageModel
    {
        private readonly IMediator _mediator;

        public InviteInstructorModel(IMediator mediator) => _mediator = mediator;

        [BindProperty]
        public CommandResult Data { get; set; }

        public class CommandResult
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public void OnGet()
        {
            
        }

        public class Validator : AbstractValidator<CommandResult>
        {
            public Validator()
            {
                RuleFor(m => m.Email).NotEmpty().EmailAddress();
                RuleFor(m => m.FirstName).NotEmpty();
                RuleFor(m => m.LastName).NotEmpty();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                // make sure we haven't already sent an invite to instructor via api call 
                // if not in gated reg DB, add to DB
                // send email to instructor
            }

            return Page();
        }
    }
}