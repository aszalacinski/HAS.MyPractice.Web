﻿using HAS.MyPractice.Web.Model;
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
    public class UpdateLibraryDefaultTribe
    {
        public class UpdateLibraryDefaultTribeCommand : IRequest<Library>
        {
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }
            public string LibraryId { get; private set; }
            public string TribeId { get; private set; }

            public UpdateLibraryDefaultTribeCommand(string profileId, string hubId, string libraryId, string tribeId)
            {
                ProfileId = profileId;
                HubId = hubId;
                LibraryId = libraryId;
                TribeId = tribeId;
            }
        }

        public class UpdateLibraryDefaultTribeCommandHandler : IRequestHandler<UpdateLibraryDefaultTribeCommand, Library>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateLibraryDefaultTribeCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Library> Handle(UpdateLibraryDefaultTribeCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.HubId}/lib/{cmd.LibraryId}/tribe/default/{cmd.TribeId}";

                _httpClient.SetBearerToken(accessToken);

                _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                var response = await _httpClient.PutAsync(uri, null);

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
