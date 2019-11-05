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
    public class UpdateTribeToNotSubscription
    {
        public class UpdateTribeToNotSubscriptionCommand : IRequest<Tribe>
        {
            public string ProfileId { get; private set; }
            public string TribeId { get; private set; }

            public UpdateTribeToNotSubscriptionCommand(string profileId, string tribeId)
            {
                ProfileId = profileId;
                TribeId = tribeId;
            }
        }

        public class UpdateTribeToNotSubscriptionCommandHandler : IRequestHandler<UpdateTribeToNotSubscriptionCommand, Tribe>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateTribeToNotSubscriptionCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Tribe> Handle(UpdateTribeToNotSubscriptionCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/{cmd.TribeId}/nsub";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.PutAsync(uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Tribe>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
