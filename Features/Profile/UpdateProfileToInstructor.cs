using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class UpdateProfileToInstructor
    {
        public class UpdateProfileToInstructorCommand : IRequest<Profile>
        {
            public string ProfileId { get; private set; }
            public UpdateProfileToInstructorCommand(string profileId) => ProfileId = profileId;
        }

        public class UpdateProfileToInstructorCommandHandler : IRequestHandler<UpdateProfileToInstructorCommand, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateProfileToInstructorCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(UpdateProfileToInstructorCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/as/in";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.PutAsync(uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Profile>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
