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
    public class GetProfileByProfileId
    {
        public class GetProfileByProfileIdQuery : IRequest<Profile>
        {
            public string ProfileId { get; private set; }

            public GetProfileByProfileIdQuery(string profileId) => ProfileId = profileId;
        }

        public class GetProfileByProfileIdQueryHandler : IRequestHandler<GetProfileByProfileIdQuery, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetProfileByProfileIdQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(GetProfileByProfileIdQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{query.ProfileId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                var profile = JsonSerializer.Deserialize<Profile>(content, DefaultJsonSettings.Settings);

                return profile;
            }
        }
    }
}
