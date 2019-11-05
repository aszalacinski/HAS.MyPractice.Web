using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


namespace HAS.MyPractice
{
    public class GetLibraryByName
    {
        public class GetLibraryByNameQuery : IRequest<Library>
        {
            public string ProfileId { get; private set; }
            public string LibraryName { get; private set; }

            public GetLibraryByNameQuery(string profileId, string libraryName)
            {
                ProfileId = profileId;
                LibraryName = libraryName;
            }
        }

        public class GetLibraryByNameQueryHandler : IRequestHandler<GetLibraryByNameQuery, Library>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetLibraryByNameQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Library> Handle(GetLibraryByNameQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{query.ProfileId}/lib/name/{query.LibraryName}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Library>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
