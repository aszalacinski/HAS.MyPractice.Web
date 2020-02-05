using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Features.InviteUser.Email
{
    public class SendStudentInviteEmail
    {
        public class SendStudentInviteEmailCommand : IRequest<Unit>
        {
            public InvitedUser User { get; private set; }
            public string InstructorName { get; private set; }

            public SendStudentInviteEmailCommand(InvitedUser user, string instructorName)
            {
                User = user;
                InstructorName = instructorName;
            }
        }

        public class SendStudentInviteEmailCommandHandler : IRequestHandler<SendStudentInviteEmailCommand, Unit>
        {
            private readonly IEmailSender _emailSender;
            private readonly IUrlHelper _urlHelper;
            private readonly IHttpContextAccessor _httpContextAcessor;

            public SendStudentInviteEmailCommandHandler(IEmailSender emailSender, IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionAccessor)
            {
                _emailSender = emailSender;
                _urlHelper = urlHelperFactory.GetUrlHelper(actionAccessor.ActionContext);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Unit> Handle(SendStudentInviteEmailCommand cmd, CancellationToken cancellationToken)
            {
                var callbackUrl = $"https://register.mypractice.yoga/Account/Register/{cmd.User.InstructorPublicName}?code={cmd.User.EntryCode}";

                await _emailSender.SendEmailAsync(cmd.User.EmailAddress, "MyPractice.Yoga - Student Invite",
                    $"Congratulations {cmd.User.FirstName} {cmd.User.LastName}! You have been invited by {cmd.InstructorName} to be a student on MyPractice.Yoga! Complete your registration at the following link: <a href=\"{callbackUrl}\">link</a>");

                return Unit.Value;
            }
        }
    }
}
