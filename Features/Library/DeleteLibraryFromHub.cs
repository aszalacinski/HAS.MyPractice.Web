using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class DeleteLibraryFromHub
    {
        public class DeleteLibraryFromHubCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }
            public string LibraryId { get; private set; }

            public DeleteLibraryFromHubCommand(string profileId, string hubId, string libraryId)
            {
                ProfileId = profileId;
                HubId = hubId;
                LibraryId = libraryId;
            }
        }

        public class DeleteLibraryFromHubCommandHandler : IRequestHandler<DeleteLibraryFromHubCommand, bool>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public DeleteLibraryFromHubCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<bool> Handle(DeleteLibraryFromHubCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.HubId}/lib/{cmd.LibraryId}";
                
                _httpClient.SetBearerToken(accessToken);
                _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                var response = await _httpClient.DeleteAsync(uri);

                if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
