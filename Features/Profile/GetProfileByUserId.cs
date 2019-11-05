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
    public class GetProfileByUserId
    {
        public class GetProfileByUserIdQuery : IRequest<Profile>
        {
            public string UserId { get; private set; }
            public string AccessToken { get; private set; }

            public GetProfileByUserIdQuery(string userId, string accessToken = null)
            {
                UserId = userId;
                AccessToken = accessToken;
            }

            public void SetAccessToken(string accessToken) => AccessToken = accessToken;
        }

        public class GetProfileByUserIdQueryHandler : IRequestHandler<GetProfileByUserIdQuery, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetProfileByUserIdQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(GetProfileByUserIdQuery query, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(query.AccessToken))
                {
                    query.SetAccessToken(await _httpContextAcessor.HttpContext.GetTokenAsync("access_token"));
                }
                
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
