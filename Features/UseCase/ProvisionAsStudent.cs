using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.AddHub;
using static HAS.MyPractice.AddLibraryToHub;
using static HAS.MyPractice.AddStudentTribe;
using static HAS.MyPractice.AddTribeToLibrary;
using static HAS.MyPractice.DeleteHub;
using static HAS.MyPractice.DeleteLibraryFromHub;
using static HAS.MyPractice.DeleteTribeFromLibrary;
using static HAS.MyPractice.UpdateLibraryAccessToPrivate;
using static HAS.MyPractice.UpdateLibraryDefaultTribe;
using static HAS.MyPractice.UpdateProfileToInstructor;
using static HAS.MyPractice.UpdateProfileToStudent;
using static HAS.MyPractice.UpdateTribeToSubscription;

namespace HAS.MyPractice
{
    public class ProvisionAsStudent
    {
        public class ProvisionAsStudentCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }

            public ProvisionAsStudentCommand(string profileId) => ProfileId = profileId;
        }

        public class ProvisionAsStudentCommandHandler : IRequestHandler<ProvisionAsStudentCommand, bool>
        {
            private readonly IMediator _mediator;

            public ProvisionAsStudentCommandHandler(IMediator mediator) => _mediator = mediator;

            public async Task<bool> Handle(ProvisionAsStudentCommand cmd, CancellationToken cancellationToken)
            {
                var profile = await _mediator.Send(new UpdateProfileToStudentCommand(cmd.ProfileId));

                if(profile != null)
                {
                    return profile.AppDetails.AccountType.ToUpper().Equals("STUDENT");
                }

                return false;
            }
        }
    }
}
