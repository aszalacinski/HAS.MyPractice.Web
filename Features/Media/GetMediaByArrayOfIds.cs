using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetMediaByArrayOfIds
    {
        public class GetMediaByArrayOfIdsQuery : IRequest<IEnumerable<Media>>
        {
            public string[] Ids { get; private set; }

            public GetMediaByArrayOfIdsQuery(string[] ids) => Ids = ids;
        }

        public class GetMediaByArrayOfIdsQueryHandler : IRequestHandler<GetMediaByArrayOfIdsQuery, IEnumerable<Media>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetMediaByArrayOfIdsQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.MEDIA);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<Media>> Handle(GetMediaByArrayOfIdsQuery query, CancellationToken cancellationToken)
            {
                var contentIds = query.Ids.Select(x => new { param = "mediaids", value = x }).ToDictionary(t => t.param, t => t.value);
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");
                
                string uri = $"multi";
                var queryString = QueryHelpers.AddQueryString(uri, contentIds);

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(queryString);

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
