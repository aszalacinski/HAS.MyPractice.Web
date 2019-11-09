using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class DeleteContentFromLibrary
    {
        public class DeleteContentFromLibraryCommand : IRequest<bool>
        {
            public string ProfileId { get; private set; }
            public string HubId { get; private set; }
            public string LibraryId { get; private set; }
            public string MediaId { get; private set; }

            public DeleteContentFromLibraryCommand(string profileId, string hubId, string libraryId, string mediaId)
            {
                ProfileId = profileId;
                HubId = hubId;
                LibraryId = libraryId;
                MediaId = mediaId;
            }
        }

        public class DeleteContentFromLibraryCommandHandler : IRequestHandler<DeleteContentFromLibraryCommand, bool>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public DeleteContentFromLibraryCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<bool> Handle(DeleteContentFromLibraryCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.HubId}/lib/{cmd.LibraryId}/content/{cmd.MediaId}";

                _httpClient.SetBearerToken(accessToken);
                _httpClient.DefaultRequestHeaders.Add("p", cmd.ProfileId);

                var response = await _httpClient.DeleteAsync(uri);

                if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
