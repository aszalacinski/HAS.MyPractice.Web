﻿using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class AddMediaToLibrary
    {
        public class AddMediaToLibraryCommand : IRequest<IEnumerable<AddMediaToLibraryResult>>
        {
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }
            public string LibraryId { get; private set; }
            public string MediaId { get; private set; }

            public AddMediaToLibraryCommand(string profileId, string hubId, string libraryId, string mediaId)
            {
                ProfileId = profileId;
                HubId = hubId;
                LibraryId = libraryId;
                MediaId = mediaId;
            }
        }

        public class AddMediaToLibraryResult
        {
            public string Id { get; set; }
            public DateTime AddDate { get; set; }
        }

        public class AddMediaToLibraryCommandHandler : IRequestHandler<AddMediaToLibraryCommand, IEnumerable<AddMediaToLibraryResult>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddMediaToLibraryCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<AddMediaToLibraryResult>> Handle(AddMediaToLibraryCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.HubId}/lib/{cmd.LibraryId}/content/{cmd.MediaId}";

                _httpClient.SetBearerToken(accessToken);
                _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                var response = await _httpClient.PutAsync(uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                var library = JsonSerializer.Deserialize<IEnumerable<AddMediaToLibraryResult>>(content, DefaultJsonSettings.Settings);

                return library;
            }
        }
    }
}
