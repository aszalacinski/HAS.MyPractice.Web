using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class UpdateMedia
    {
        public class UpdateMediaCommand : IRequest<string>
        {
            public string ProfileId { get; private set; }
            public string MediaId { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public long Duration { get; private set; }

            public UpdateMediaCommand(string profileId, string mediaId, string title, string description, long duration)
            {
                ProfileId = profileId;
                MediaId = mediaId;
                Title = title;
                Description = description;
                Duration = duration;
            }

            public class UpdateMediaResult
            {
                public string MediaId { get; set; }
                public string InstructorId { get; set; }
            }

            public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, string>
            {
                private readonly IHttpContextAccessor _httpContextAcessor;
                private readonly HttpClient _httpClient;

                public UpdateMediaCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
                {
                    _httpClient = httpClientFactory.CreateClient(HASClientFactories.MEDIA);
                    _httpContextAcessor = httpContextAccessor;
                }

                public async Task<string> Handle(UpdateMediaCommand cmd, CancellationToken cancellationToken)
                {
                    var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                    string uri = $"{cmd.MediaId}";

                    _httpClient.SetBearerToken(accessToken);
                    _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                    var payload = new { Title = cmd.Title, Description = cmd.Description, Duration = cmd.Duration };

                    var json = JsonSerializer.Serialize(payload, DefaultJsonSettings.Settings);

                    var postContent = new StringContent(json, Encoding.UTF8, "application/json");

                    // call the api endpointendpoint
                    var response = await _httpClient.PutAsync(uri, postContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return string.Empty;
                    }

                    // read the response
                    var content = await response.Content.ReadAsStringAsync();
                    
                    var dao = JsonSerializer.Deserialize<UpdateMediaResult>(content, DefaultJsonSettings.Settings);

                    return dao.MediaId;
                }
            }
        }
    }
}
