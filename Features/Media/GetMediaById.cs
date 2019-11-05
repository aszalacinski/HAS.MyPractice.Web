using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetMediaById
    {
        public class GetMediaByIdQuery : IRequest<Media>
        {
            public string MediaId { get; private set; }

            public GetMediaByIdQuery(string mediaId)
            {
                MediaId = mediaId;
            }
        }

        public class GetMedaByIdQueryHandler : IRequestHandler<GetMediaByIdQuery, Media>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetMedaByIdQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.MEDIA);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Media> Handle(GetMediaByIdQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{query.MediaId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Media>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
