using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Features.InviteUser.GatedRegistration
{
    public class GetAllPendingStudentInvitesByInstructor
    {
        public class GetAllPendingStudentInvitesByInstructorQuery : IRequest<IEnumerable<InvitedUser>>
        {
            public string InstructorId { get; private set; }

            public GetAllPendingStudentInvitesByInstructorQuery(string instructorId) 
            {
                InstructorId = instructorId;
            }
        }

        public class GetAllPendingStudentInvitesByInstructorHandler : IRequestHandler<GetAllPendingStudentInvitesByInstructorQuery, IEnumerable<InvitedUser>>
        {
            public readonly GatedRegistrationContext _db;
            private readonly MapperConfiguration _mapperConfiguration;

            public GetAllPendingStudentInvitesByInstructorHandler(GatedRegistrationContext db)
            {
                _db = db;
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<InvitedUserProfile>();
                });
            }

            public async Task<IEnumerable<InvitedUser>> Handle(GetAllPendingStudentInvitesByInstructorQuery cmd, CancellationToken cancellationToken)
            {
                var pendingInvites = await _db.Users.Find(x => x.Invited == true && x.Registered == false && x.InstructorId == cmd.InstructorId).ToListAsync();

                var mapper = new Mapper(_mapperConfiguration);

                var pInvites = mapper.Map<IEnumerable<InvitedUser>>(pendingInvites);

                return pInvites;

            }
        }
    }
}
