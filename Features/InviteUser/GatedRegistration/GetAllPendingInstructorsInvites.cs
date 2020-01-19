using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistrationContext;

namespace HAS.MyPractice.Web.Features.InviteUser.GatedRegistration
{
    public class GetAllPendingInstructorsInvites
    {
        public class GetAllPendingInstructorsInvitesQuery : IRequest<IEnumerable<InvitedUser>>
        {
            public GetAllPendingInstructorsInvitesQuery() { }
        }

        public class GetAllPendingInstructorsInvitesQueryHandler : IRequestHandler<GetAllPendingInstructorsInvitesQuery, IEnumerable<InvitedUser>>
        {
            public readonly GatedRegistrationContext _db;
            private readonly MapperConfiguration _mapperConfiguration;

            public GetAllPendingInstructorsInvitesQueryHandler(GatedRegistrationContext db)
            {
                _db = db;
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<InvitedUserProfile>();
                });
            }

            public async Task<IEnumerable<InvitedUser>> Handle(GetAllPendingInstructorsInvitesQuery request, CancellationToken cancellationToken)
            {
                var pendingInvites = await _db.Users.Find(x => x.Invited == true && x.Registered == false).ToListAsync();
                
                var mapper = new Mapper(_mapperConfiguration);

                var pInvites = mapper.Map<IEnumerable<InvitedUser>>(pendingInvites);

                return pInvites;

            }
        }
    }
}
