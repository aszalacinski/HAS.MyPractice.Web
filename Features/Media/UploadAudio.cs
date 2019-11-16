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
    public class UploadAudio
    {
        public class UploadAudioCommand : IRequest<string>
        {
            public MultipartFormDataContent FormDataContent { get; private set; }

            public UploadAudioCommand(MultipartFormDataContent formDataContent)
            {
                FormDataContent = formDataContent;
            }
        }

        public class UploadAudioCommandHandler : IRequestHandler<UploadAudioCommand, string>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UploadAudioCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.UPLOAD);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<string> Handle(UploadAudioCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"audio";

                _httpClient.SetBearerToken(accessToken);

                // call the api endpointendpoint
                var response = await _httpClient.PostAsync(uri, cmd.FormDataContent);

                // read the response
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var dao = JsonSerializer.Deserialize<Media>(content, DefaultJsonSettings.Settings);

                return dao.Id;
            }
        }
    }
}
