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
    public class AddHub
    {
        public class AddHubCommand : IRequest<Hub>
        {
            public string ProfileId { get; private set; }

            public AddHubCommand(string profileId) => ProfileId = profileId;
        }

        public class AddHubCommandHandler : IRequestHandler<AddHubCommand, Hub>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddHubCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Hub> Handle(AddHubCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.PostAsync(uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Hub>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
