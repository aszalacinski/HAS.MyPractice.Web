using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.GetProfileByUserId;
using static HAS.MyPractice.Web.Features.Alert.ThrowAlert;
using static HAS.MyPractice.Web.Features.Profile.GetScreenName;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class ProfileModel : PageModel
    {
        private readonly IMediator _mediator;

        public ProfileModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public UpdateStudentProfileCommand Model { get; set; }

        public async Task OnGet()
        {
            string userId = HttpContext.User.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault().Value;
            Profile profile = await _mediator.Send(new GetProfileByUserIdQuery(userId));

            Model = new UpdateStudentProfileCommand
            {
                ProfileId = profile.Id,
                FirstName = profile.PersonalDetails.FirstName,
                LastName = profile.PersonalDetails.LastName,
                ScreenName = profile.PersonalDetails.ScreenName,
                Email = profile.PersonalDetails.Email
            };
        }

        public class UpdateStudentProfileCommand : IRequest<Profile>
        {
            public string ProfileId { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Screen Name")]
            public string ScreenName { get; set; }
            [Display(Name = "Email")]
            public string Email { get; set; }

        }

        public async Task OnPost()
        {
            if(string.IsNullOrEmpty(Model.ScreenName))
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
                    await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Personal Details Failure", "An error occurred during the update of the profile personal details."));
                }
            }
            catch(UpdatePersonalDetailsException ex)
            {
                await _mediator.Send(new ThrowAlertCommand(AlertType.DANGER, "Update Personal Details Failure", ex.Message));
            }
        }

        public class UpdateStudentProfileCommandHandler : IRequestHandler<UpdateStudentProfileCommand, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateStudentProfileCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(UpdateStudentProfileCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/upd";

                _httpClient.SetBearerToken(accessToken);

                var payload = new { cmd.FirstName, cmd.LastName, cmd.ScreenName };

                var json = JsonSerializer.Serialize(payload, DefaultJsonSettings.Settings);

                var putContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(uri, putContent);

                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new UpdatePersonalDetailsException(content);
                }

                return JsonSerializer.Deserialize<Profile>(content, DefaultJsonSettings.Settings);
            }
        }

        public class UpdatePersonalDetailsException : Exception
        {
            public UpdatePersonalDetailsException(string message) : base(message) { }

            public UpdatePersonalDetailsException(string message, Exception exception) : base(message, exception) { }
        }
    }
}