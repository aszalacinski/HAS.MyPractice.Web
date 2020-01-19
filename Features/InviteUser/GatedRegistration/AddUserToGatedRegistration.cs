using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistrationContext;

namespace HAS.MyPractice.Web.Features.InviteUser
{
    public class AddUserToGatedRegistration
    {
        public class AddUserToGatedRegistrationCommand : IRequest<bool>
        {
            public InvitedUser User { get; private set; }

            public AddUserToGatedRegistrationCommand(InvitedUser user)
            {
                User = user;
            }
        }

        public class AddUserToGatedRegistrationCommandHandler : IRequestHandler<AddUserToGatedRegistrationCommand, bool>
        {
            public readonly GatedRegistrationContext _db;
            private readonly MapperConfiguration _mapperConfiguration;

            public AddUserToGatedRegistrationCommandHandler(GatedRegistrationContext db)
            {
                _db = db;
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<InvitedUserDAOProfile>();
                });
            }

            public async Task<bool> Handle(AddUserToGatedRegistrationCommand cmd, CancellationToken cancellationToken)
            {

                var mapper = new Mapper(_mapperConfiguration);

                var dao = mapper.Map<InvitedUserDAO>(cmd.User);

                try
                {
                    await _db.Users.InsertOneAsync(dao);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }
}
