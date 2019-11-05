using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.AddHub;
using static HAS.MyPractice.AddLibraryToHub;
using static HAS.MyPractice.AddStudentTribe;
using static HAS.MyPractice.AddTribeToLibrary;
using static HAS.MyPractice.DeleteHub;
using static HAS.MyPractice.DeleteLibraryFromHub;
using static HAS.MyPractice.DeleteTribeFromLibrary;
using static HAS.MyPractice.GetHubByProfileId;
using static HAS.MyPractice.GetProfileByProfileId;
using static HAS.MyPractice.UpdateLibraryAccessToPrivate;
using static HAS.MyPractice.UpdateLibraryDefaultTribe;
using static HAS.MyPractice.UpdateProfileToInstructor;
using static HAS.MyPractice.UpdateProfileToStudent;
using static HAS.MyPractice.UpdateTribeToSubscription;

namespace HAS.MyPractice
{
    public class ProvisionAsInstructor
    {
        public class ProvisionAsInstructorCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }

            public ProvisionAsInstructorCommand(string profileId) => ProfileId = profileId;
        }

        public class ProvisionAsInstructorCommandHandler : IRequestHandler<ProvisionAsInstructorCommand, bool>
        {
            private readonly IMediator _mediator;

            public ProvisionAsInstructorCommandHandler(IMediator mediator) => _mediator = mediator;

            public async Task<bool> Handle(ProvisionAsInstructorCommand cmd, CancellationToken cancellationToken)
            {
                string profileId = cmd.ProfileId;
                string hubId = string.Empty;
                string libraryId = string.Empty;
                string tribeId = string.Empty;

                var profile = await _mediator.Send(new GetProfileByProfileIdQuery(profileId));

                if(profile.IsInstructor())
                {
                    return true;
                }

                var profileUpdatedToInstructor = await _mediator.Send(new UpdateProfileToInstructorCommand(profileId));

                if(profileUpdatedToInstructor.AppDetails.AccountType.ToUpper().Equals("INSTRUCTOR"))
                {
                    var hubCheck = await _mediator.Send(new GetHubByProfileIdQuery(profileId));

                    if(hubCheck != null)
                    {
                        return true;
                    }

                    var hub = await _mediator.Send(new AddHubCommand(profileId));

                    if (hub.InstructorId.Equals(profileId))
                    {
                        hubId = hub.Id;

                        string libraryTitle = $"Default-{profileId}.{hubId}";
                        string libraryDescription = $"Default library for an instructor account. This library cannot be deleted. All files uploaded will appear in this library";

                        var library = await _mediator.Send(new AddLibraryToHubCommand(profileId, hubId, libraryTitle, libraryDescription));

                        var hubWithLibrary = await _mediator.Send(new GetHubByProfileIdQuery(profileId));

                        if(hubWithLibrary.Libraries.Any(x => x.Id == library.Id))
                        {
                            libraryId = library.Id;
                            var updatedLibraryToPrivate = await _mediator.Send(new UpdateLibraryAccessToPrivateCommand(profileId, hubId, libraryId));
                            
                            if(updatedLibraryToPrivate.Id.Equals(libraryId) && updatedLibraryToPrivate.Access.Equals("PRIVATE"))
                            {
                                string tribeTitle = $"Default-{profileId}.{hubId}.{libraryId}";
                                string tribeDesc = $"Default tribe for an instructor account. This tribe cannot be deleted. This is the location where subscribed students go";

                                var tribe = await _mediator.Send(new AddStudentTribeCommand(profileId, tribeTitle, tribeDesc));

                                if(tribe.InstructorId.Equals(profileId) && tribe.Type.ToUpper().Equals("STUDENT"))
                                {
                                    tribeId = tribe.Id;
                                    var updateTribeToSubscription = await _mediator.Send(new UpdateTribeToSubscriptionCommand(profileId, tribeId));

                                    if(updateTribeToSubscription.IsSubscription == true)
                                    {
                                        var addTribeToLibrary = await _mediator.Send(new AddTribeToLibraryCommand(profileId, hubId, libraryId, tribeId));

                                        if(addTribeToLibrary.Tribes.Any(x => x.Id == tribeId))
                                        {
                                            var updateLibraryDefaultTribe = await _mediator.Send(new UpdateLibraryDefaultTribeCommand(profileId, hubId, libraryId, tribeId));

                                            if (updateLibraryDefaultTribe != null && updateLibraryDefaultTribe.DefaultTribe.Id == tribeId)
                                            {
                                                return profile.AppDetails.AccountType.ToUpper().Equals("INSTRUCTOR"); ;
                                            }
                                            else
                                            {
                                                var removeTribeFromLibrary = await _mediator.Send(new DeleteTribeFromLibraryCommand(profileId, hubId, libraryId, tribeId));
                                                var deleteLibrary = await _mediator.Send(new DeleteLibraryFromHubCommand(profileId, hubId, libraryId));
                                                var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                                                var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            var deleteLibrary = await _mediator.Send(new DeleteLibraryFromHubCommand(profileId, hubId, libraryId));
                                            var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                                            var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        var deleteLibrary = await _mediator.Send(new DeleteLibraryFromHubCommand(profileId, hubId, libraryId));
                                        var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                                        var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                                        return false;
                                    }
                                }
                                else
                                {
                                    var deleteLibrary = await _mediator.Send(new DeleteLibraryFromHubCommand(profileId, hubId, libraryId));
                                    var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                                    var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                                    return false;
                                }
                            }
                            else
                            {
                                var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                                var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                                return false;
                            }
                        }
                        else
                        {
                            var deleteHub = await _mediator.Send(new DeleteHubCommand(profileId, hubId));
                            var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));

                            return false;
                        }
                    }
                    else
                    {
                        var rollbackStudentToInstructor = await _mediator.Send(new UpdateProfileToStudentCommand(profileId));
                        return false;
                    }
                }
                else
                {
                    return false;
                }                             
            }
        }
    }
}
