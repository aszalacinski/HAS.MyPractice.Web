using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class AddLibraryToHub
    {
        public class AddLibraryToHubCommand : IRequest<Library> 
        { 
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }
            public string Name { get; private set; }
            public string Description { get; private set; }

            public AddLibraryToHubCommand(string profileId, string hubId, string name, string description)
            {
                ProfileId = profileId;
                HubId = hubId;
                Name = name;
                Description = description;
            }
        }

        public class AddLibraryToHubCommandHandler : IRequestHandler<AddLibraryToHubCommand, Library>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddLibraryToHubCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Library> Handle(AddLibraryToHubCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.HubId}/lib";

                _httpClient.SetBearerToken(accessToken);
                _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                var payload = new { Name = cmd.Name, Description = cmd.Description };

                var json = JsonSerializer.Serialize(payload, DefaultJsonSettings.Settings);

                var postContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, postContent);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Library>(content, DefaultJsonSettings.Settings);
            }
        }

    }
}
