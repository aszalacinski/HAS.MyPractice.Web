using MongoDB.Bson;
using static HAS.MyPractice.Web.Features.InviteUser.GatedRegistrationContext;

namespace HAS.MyPractice.Web.Features.InviteUser
{
    public class InvitedUserDAOProfile : AutoMapper.Profile
    {
        public InvitedUserDAOProfile()
        {
            CreateMap<InvitedUser, InvitedUserDAO>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? ObjectId.GenerateNewId() : ObjectId.Parse(src.Id)));
            CreateMap<InvitedUserLogEntry, InvitedUserLogEntryDAO>();
        }
    }

    public class InvitedUserProfile : AutoMapper.Profile
    {
        public InvitedUserProfile()
        {
            CreateMap<InvitedUserDAO, InvitedUser>();
            CreateMap<InvitedUserLogEntryDAO, InvitedUserLogEntry>();
        }
    }
}
