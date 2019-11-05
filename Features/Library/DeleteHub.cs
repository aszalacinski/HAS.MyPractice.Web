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
    public class DeleteHub
    {
        public class DeleteHubCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }

            public DeleteHubCommand(string profileId, string hubId)
            {
                ProfileId = profileId;
                HubId = hubId;
            }
        }

        public class DeleteHubCommandHandler : IRequestHandler<DeleteHubCommand, bool>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public DeleteHubCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<bool> Handle(DeleteHubCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/d/{cmd.HubId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.DeleteAsync(uri);

                if(response.StatusCode.Equals(HttpStatusCode.NoContent))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
