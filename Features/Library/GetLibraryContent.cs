using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetLibraryContent
    {
        public class GetLibraryContentQuery : IRequest<IEnumerable<Content>>
        {
            public string HubId { get; private set; }
            public string LibraryId { get; private set; }

            public GetLibraryContentQuery(string hubId, string libraryId)
            {
                HubId = hubId;
                LibraryId = libraryId;
            }
        }

        public class GetLibraryContentQueryHandler : IRequestHandler<GetLibraryContentQuery, IEnumerable<Content>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetLibraryContentQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<Content>> Handle(GetLibraryContentQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{query.HubId}/lib/{query.LibraryId}/content";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<Content>>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
