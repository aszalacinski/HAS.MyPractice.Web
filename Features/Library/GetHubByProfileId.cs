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
    public class GetHubByProfileId
    {
        public class GetHubByProfileIdQuery : IRequest<Hub> 
        { 
            public string ProfileId { get; private set; }

            public GetHubByProfileIdQuery(string profileId) => ProfileId = profileId;
        }

        public class GetHubByProfileIdQueryHander : IRequestHandler<GetHubByProfileIdQuery, Hub>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetHubByProfileIdQueryHander(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Hub> Handle(GetHubByProfileIdQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"i/{query.ProfileId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Hub>(content, DefaultJsonSettings.Settings);
            }
        }

    }
}
