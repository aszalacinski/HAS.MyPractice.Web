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
    public class AddStudentTribe
    {
        public class AddStudentTribeCommand : IRequest<Tribe>
        {
            public string ProfileId { get; private set; }
            public string Name { get; private set; }
            public string Description { get; private set; }

            public AddStudentTribeCommand(string profileId, string name, string description)
            {
                ProfileId = profileId;
                Name = name;
                Description = description;
            }
        }

        public class AddStudentTribeCommandHandler : IRequestHandler<AddStudentTribeCommand, Tribe>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddStudentTribeCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Tribe> Handle(AddStudentTribeCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/a/stu";

                _httpClient.SetBearerToken(accessToken);

                var payload = new { Name = cmd.Name, Description = cmd.Description };

                var json = JsonSerializer.Serialize(payload, DefaultJsonSettings.Settings);

                var postContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, postContent);

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
