using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetSubscriptionsByProfileId
    {
        public class GetSubscriptionsByProfileIdQuery : IRequest<string[]>
        {
            public string ProfileId { get; private set; }

            public GetSubscriptionsByProfileIdQuery(string profileId) => ProfileId = profileId;
        }

        public class GetSubscriptionsByProfileIdQueryHandler : IRequestHandler<GetSubscriptionsByProfileIdQuery, string[]>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetSubscriptionsByProfileIdQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<string[]> Handle(GetSubscriptionsByProfileIdQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{query.ProfileId}/subs";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);
                
                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<string[]>(content, DefaultJsonSettings.Settings);

            }
        }
    }
}
