using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetProfileByUserId
    {
        public class GetProfileByUserIdQuery : IRequest<Profile>
        {
            public string UserId { get; private set; }
            public string AccessToken { get; private set; }

            public GetProfileByUserIdQuery(string userId, string accessToken)
            {
                UserId = userId;
                AccessToken = accessToken;
            }
        }

        public class GetProfileByUserIdQueryHandler : IRequestHandler<GetProfileByUserIdQuery, Profile>
        {
            private readonly HttpClient _httpClient;

            public GetProfileByUserIdQueryHandler(IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
            }

            public async Task<Profile> Handle(GetProfileByUserIdQuery query, CancellationToken cancellationToken)
            {
                string uri = $"by/{query.UserId}";

                _httpClient.SetBearerToken(query.AccessToken);

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
