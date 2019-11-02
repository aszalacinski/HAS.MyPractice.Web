using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
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
            public string AccessToken { get; private set; }
            public MultipartFormDataContent FormDataContent { get; private set; }

            public UploadAudioCommand(string accessToken, MultipartFormDataContent formDataContent)
            {
                AccessToken = accessToken;
                FormDataContent = formDataContent;
            }
        }

        public class UploadAudioCommandHandler : IRequestHandler<UploadAudioCommand, string>
        {
            private readonly HttpClient _httpClient;

            public UploadAudioCommandHandler(IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.MEDIA);
            }

            public async Task<string> Handle(UploadAudioCommand cmd, CancellationToken cancellationToken)
            {
                string uri = $"new";

                _httpClient.SetBearerToken(cmd.AccessToken);

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
