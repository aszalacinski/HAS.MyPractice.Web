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
    public class DeleteTribe
    {
        public class DeleteTribeCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }
            public string TribeId { get; private set; }

            public DeleteTribeCommand(string profileId, string tribeId)
            {
                ProfileId = profileId;
                TribeId = tribeId;
            }
        }

        public class DeleteTribeCommandHandler : IRequestHandler<DeleteTribeCommand, bool>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public DeleteTribeCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<bool> Handle(DeleteTribeCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/d/{cmd.TribeId}";

                _httpClient.SetBearerToken(accessToken);

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
