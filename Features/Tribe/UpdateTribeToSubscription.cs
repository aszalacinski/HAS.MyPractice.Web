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
    public class UpdateTribeToSubscription
    {
        public class UpdateTribeToSubscriptionCommand : IRequest<Tribe>
        {
            public string ProfileId { get; private set; }
            public string TribeId { get; private set; }

            public UpdateTribeToSubscriptionCommand(string profileId, string tribeId)
            {
                ProfileId = profileId;
                TribeId = tribeId;
            }
        }

        public class UpdateTribeToSubscriptionCommandHandler : IRequestHandler<UpdateTribeToSubscriptionCommand, Tribe>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateTribeToSubscriptionCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Tribe> Handle(UpdateTribeToSubscriptionCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/{cmd.TribeId}/sub";

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
