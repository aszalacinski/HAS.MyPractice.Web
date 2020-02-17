using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HAS.MyPractice.Web.Features.InviteUser;
using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetProfileByUserId;
using static HAS.MyPractice.Web.Features.Alert.ThrowAlert;
using static HAS.MyPractice.Web.Features.InviteUser.AddUserToGatedRegistration;
using static HAS.MyPractice.Web.Features.InviteUser.Email.SendStudentInviteEmail;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistration.GenerateRandomEntryCode;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistration.GetAllPendingStudentInvitesByInstructor;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistration.GetUserInGatedRegistrationByEmailAddress;

namespace HAS.MyPractice.Web
{
    public class InviteStudentModel : PageModel
    {
        private readonly IMediator _mediator;

        public InviteStudentModel(IMediator mediator) => _mediator = mediator;

        [BindProperty]
        public CommandResult Data { get; set; }

        public class CommandResult
        {
            public string Email { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            public string InstructorId { get; set; }
            public string InstructorName { get; set; }
            public string InstructorPublicName { get; set; }
            public IEnumerable<InvitedUser> Pending { get; set; }
        }


        public async Task OnGet()
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;
            Profile profile = await _mediator.Send(new GetProfileByUserIdQuery(userId));

            Data = new CommandResult()
            {
                InstructorId = profile.Id,
                InstructorPublicName = profile.AppDetails.InstructorDetails.PublicName,
                InstructorName = $"{profile.PersonalDetails.FirstName} {profile.PersonalDetails.LastName}"
            };

            Data.Pending = await _mediator.Send(new GetAllPendingStudentInvitesByInstructorQuery(profile.Id));
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
            if (ModelState.IsValid)
            {
                // make sure we haven't already sent an invite to student via api call 
                var invitedStudent = await _mediator.Send(new GetUserInGatedRegistrationByEmailAddressQuery(Data.Email));
                // if not in gated reg DB, 
                if (invitedStudent == null)
                {
                    var entryCode = await _mediator.Send(new GenerateRandomEntryCodeQuery(8));

                    // add to DB
                    var studentUser = InvitedUser.Create(string.Empty, Data.FirstName, Data.LastName, Data.Email, Data.InstructorId, Data.InstructorPublicName, entryCode, false, true, DateTime.MinValue, new List<InvitedUserLogEntry>());
                    studentUser.Log(false, 200, entryCode);

                    var addStudent = await _mediator.Send(new AddUserToGatedRegistrationCommand(studentUser));

                    if (addStudent)
                    {
                        // send email to student

                        await _mediator.Send(new SendStudentInviteEmailCommand(studentUser, Data.InstructorName));

                        await _mediator.Send(new ThrowAlertCommand(AlertType.SUCCESS, $"{Data.FirstName} {Data.LastName} was invited to join as a Student!", $"An email was sent to {Data.FirstName} using {Data.Email}"));

                    }
                    else
                    {
                        await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, $"{Data.FirstName} {Data.LastName} could not be invited as a Student!", $"An email was not sent to {Data.FirstName} using {Data.Email}; there appears to have been a problem with adding {Data.FirstName} to the Gated Registration Database."));
                    }


                    return RedirectToPage();

                }
                else
                {
                    ModelState.AddModelError("Email", "Student has already been invited");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostResendInvite(string firstName, string lastName, string emailAddress, string entryCode, string instructorId, string instructorPublicName, string instructorName)
        {
            var studentUser = InvitedUser.Create(string.Empty, firstName, lastName, emailAddress, instructorId, instructorPublicName, entryCode, false, true, DateTime.MinValue, new List<InvitedUserLogEntry>());

            await _mediator.Send(new SendStudentInviteEmailCommand(studentUser, instructorName));

            await _mediator.Send(new ThrowAlertCommand(AlertType.SUCCESS, $"Invite to join has been resent to {firstName} {lastName}!", $"Another email was sent to {Data.FirstName} using {Data.Email}"));

            return RedirectToPage();
        }

    }
}