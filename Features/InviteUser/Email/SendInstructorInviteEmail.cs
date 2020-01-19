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

namespace HAS.MyPractice.Web.Features.InviteUser
{
    public class SendInstructorInviteEmail
    {
        public class SendInstructorInviteEmailCommand : IRequest<Unit>
        {
            public InvitedUser User { get; private set; }

            public SendInstructorInviteEmailCommand(InvitedUser user) => User = user;
        }

        public class SendInstructorInviteEmailCommandHandler : IRequestHandler<SendInstructorInviteEmailCommand, Unit>
        {
            private readonly IEmailSender _emailSender;
            private readonly IUrlHelper _urlHelper;
            private readonly IHttpContextAccessor _httpContextAcessor;

            public SendInstructorInviteEmailCommandHandler(IEmailSender emailSender, IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor, IActionContextAccessor actionAccessor)
            {
                _emailSender = emailSender;
                _urlHelper = urlHelperFactory.GetUrlHelper(actionAccessor.ActionContext);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Unit> Handle(SendInstructorInviteEmailCommand cmd, CancellationToken cancellationToken)
            {
                var callbackUrl = $"https://register.mypractice.yoga/Account/Register/Instructor?code={cmd.User.EntryCode}";

                await _emailSender.SendEmailAsync(cmd.User.EmailAddress, "MyPractice.Yoga - Instructor Invite",
                    $"Congratulations! You have been invited to be an Instructor on MyPractice.Yoga! Complete your registration at the following link: <a href=\"{callbackUrl}\">link</a>");

                return Unit.Value;
            }
        }
    }
}
