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
    public class GetAllMediaByProfileId
    {
        public class GetAllMediaByProfileIDQuery : IRequest<IEnumerable<Media>>
        {
            public string ProfileId { get; private set; }

            public GetAllMediaByProfileIDQuery(string profileId)
            {
                ProfileId = profileId;
            }

            public class GetAllMediaByProfileIdQueryHandler : IRequestHandler<GetAllMediaByProfileIDQuery, IEnumerable<Media>>
            {
                private readonly IHttpContextAccessor _httpContextAcessor;
                private readonly HttpClient _httpClient;

                public GetAllMediaByProfileIdQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
                {
                    _httpClient = httpClientFactory.CreateClient(HASClientFactories.MEDIA);
                    _httpContextAcessor = httpContextAccessor;
                }

                public async Task<IEnumerable<Media>> Handle(GetAllMediaByProfileIDQuery query, CancellationToken cancellationToken)
                {
                    var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                    string uri = $"all/{query.ProfileId}";

                    _httpClient.SetBearerToken(accessToken);

                    var response = await _httpClient.GetAsync(uri);

                    if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                    {
                        return JsonSerializer.Deserialize<IEnumerable<Media>>("[]", DefaultJsonSettings.Settings);
                    }

                    var content = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<IEnumerable<Media>>(content, DefaultJsonSettings.Settings);
                }
            }
        }
    }
}
