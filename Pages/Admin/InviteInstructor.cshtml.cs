using FluentValidation;
using HAS.MyPractice.Web.Features.InviteUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static HAS.MyPractice.Web.Features.Alert.ThrowAlert;
using static HAS.MyPractice.Web.Features.InviteUser.AddUserToGatedRegistration;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistration.GenerateRandomEntryCode;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistration.GetUserInGatedRegistrationByEmailAddress;

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
            Data = new CommandResult();
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
                var invitedInstructor = await _mediator.Send(new GetUserInGatedRegistrationByEmailAddressQuery(Data.Email));
                // if not in gated reg DB, 
                if(invitedInstructor == null)
                {
                    var entryCode = await _mediator.Send(new GenerateRandomEntryCodeQuery(8));

                    // add to DB
                    var instructorUser = InvitedUser.Create(string.Empty, Data.FirstName, Data.LastName, Data.Email, string.Empty, entryCode, false, true, DateTime.MinValue, new List<InvitedUserLogEntry>());
                    instructorUser.Log(false, 200, entryCode);

                    var addInstructor = await _mediator.Send(new AddUserToGatedRegistrationCommand(instructorUser));

                    if(addInstructor)
                    {
                        // send email to instructor

                        await _mediator.Send(new ThrowAlertCommand(AlertType.SUCCESS, $"{Data.FirstName} {Data.LastName} was invited to join as an Instructor!", $"An email was sent to {Data.FirstName} using {Data.Email}"));

                    }
                    else
                    {
                        await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, $"{Data.FirstName} {Data.LastName} could not be invited as an Instructor!", $"An email was not sent to {Data.FirstName} using {Data.Email}; there appears to have been a problem with adding {Data.FirstName} to the Gated Registration Database."));
                    }

                    
                    return RedirectToPage();

                } else
                {
                    ModelState.AddModelError("Email", "Instructor has already been invited");
                }
            }

            return Page();
        }
    }
}