using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetProfileByUserId;
using static HAS.MyPractice.Web.Features.Alert.ThrowAlert;
using static HAS.MyPractice.Web.Features.Profile.GetScreenName;
using static HAS.MyPractice.Web.Pages.Student.ProfileModel;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class ProfileModel : PageModel
    {
        private readonly IMediator _mediator;

        public ProfileModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public UpdateInstructorProfileCommand Model { get; set; }

        public async Task OnGet()
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;
            Profile profile = await _mediator.Send(new GetProfileByUserIdQuery(userId));

            Model = new UpdateInstructorProfileCommand
            {
                ProfileId = profile.Id,
                FirstName = profile.PersonalDetails.FirstName,
                LastName = profile.PersonalDetails.LastName,
                ScreenName = profile.PersonalDetails.ScreenName,
                Email = profile.PersonalDetails.Email,
                PublicName = profile.AppDetails.InstructorDetails.PublicName
            };
        }

        public class UpdateInstructorProfileCommand : IRequest<Profile>
        {
            public string ProfileId { get; set; }
            [Display(Name="First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Screen Name")]
            public string ScreenName { get; set; }
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Display(Name = "Public Name")]
            public string PublicName { get; set; }
        }

        public class Validator : AbstractValidator<UpdateInstructorProfileCommand>
        {
            public Validator()
            {
                RuleFor(m => m.FirstName).NotEmpty();
                RuleFor(m => m.LastName).NotEmpty();
                RuleFor(m => m.PublicName).NotEmpty();
            }
        }

        public async Task OnPost()
        {
            if (string.IsNullOrEmpty(Model.ScreenName))
            {
                Model.ScreenName = await _mediator.Send(new GetScreenNameQuery(Model.FirstName, Model.LastName, Model.Email));
            }

            try
            {
                var profile = await _mediator.Send(Model);

                if(profile != null)
                {
                    await _mediator.Send(new ThrowAlertCommand(AlertType.SUCCESS, "Update Personal Details Success", "Your profile personal details have been updated"));
                }
                else
                {
                    await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Instructor Details Failure", "An error occurred during the update of the profile instructor details."));
                }

            }
            catch(UpdatePersonalDetailsException ex)
            {
                await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Personal Details Failure", ex.Message));
            }
            catch(UpdateInstructorDetailsException ex)
            {
                await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Instructor Details Failure", ex.Message));
            }
            catch(InstructorPublicNameException ex)
            {
                await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Instructor Details Failure", ex.Message));
            }
        }

        public class UpdateInstructorProfileCommandHandler : IRequestHandler<UpdateInstructorProfileCommand, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateInstructorProfileCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(UpdateInstructorProfileCommand cmd, CancellationToken cancellationToken)
            {
                string errorMsg = string.Empty;

                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                _httpClient.SetBearerToken(accessToken);
                
                // update personal details
                string updatePersonalUri = $"{cmd.ProfileId}/upd";

                var personalPayload = new { cmd.FirstName, cmd.LastName, cmd.ScreenName };

                var personalJson = JsonSerializer.Serialize(personalPayload, DefaultJsonSettings.Settings);

                var pContent = new StringContent(personalJson, Encoding.UTF8, "application/json");

                var pResponse = await _httpClient.PutAsync(updatePersonalUri, pContent);

                var prContent = await pResponse.Content.ReadAsStringAsync();

                if(!pResponse.IsSuccessStatusCode)
                {
                    throw new UpdatePersonalDetailsException(prContent);
                }

                // make sure publicname is original

                string nameCheckUri = $"by/publicName/{cmd.PublicName}";

                var iProfile = await _httpClient.GetAsync(nameCheckUri);

                var ncContent = await iProfile.Content.ReadAsStringAsync();

                var profile = JsonSerializer.Deserialize<Profile>(ncContent, DefaultJsonSettings.Settings);
                
                if (iProfile.StatusCode == HttpStatusCode.NotFound)
                {

                    // update instructor details
                    string updateInstructorUri = $"{cmd.ProfileId}/updi";

                    var instructorPayload = new { cmd.PublicName };

                    var instructorJson = JsonSerializer.Serialize(instructorPayload, DefaultJsonSettings.Settings);

                    var iContent = new StringContent(instructorJson, Encoding.UTF8, "application/json");

                    var iResponse = await _httpClient.PutAsync(updateInstructorUri, iContent);

                    var irContent = await iResponse.Content.ReadAsStringAsync();

                    if (!iResponse.IsSuccessStatusCode)
                    {
                        throw new UpdateInstructorDetailsException(irContent);
                    }

                    return JsonSerializer.Deserialize<Profile>(irContent, DefaultJsonSettings.Settings);
                }
                else
                {
                    // if instructor submits with no changes to public name... ignore
                    if (profile.Id != cmd.ProfileId)
                    {
                        throw new InstructorPublicNameException($"The public name {cmd.PublicName} is not available for use. Please choose a different one.");
                    }

                    return profile;
                }

            }
        }

        public class UpdateInstructorDetailsException : Exception
        {
            public UpdateInstructorDetailsException(string message) : base(message) { }

            public UpdateInstructorDetailsException(string message, Exception exception) : base(message, exception) { }
        }
    }
}