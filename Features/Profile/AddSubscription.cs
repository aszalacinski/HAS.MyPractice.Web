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
    public class AddSubscription
    {
        public class AddSubscriptionCommand : IRequest<Profile>
        {
            public string ProfileId { get; private set; }
            public string InstructorId { get; private set; }

            public AddSubscriptionCommand(string profileId, string instructorId)
            {
                ProfileId = profileId;
                InstructorId = instructorId;
            }
        }

        public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddSubscriptionCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(AddSubscriptionCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/sub/add/{cmd.InstructorId}";

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
