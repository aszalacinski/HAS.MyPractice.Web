using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetLibraryContentByArrayOfInstructorIds
    {
        public class GetLibraryContentByArrayOfInstructorIdsQuery : IRequest<IEnumerable<Media>>
        {
            public string[] InstructorIds { get; private set; }

            public GetLibraryContentByArrayOfInstructorIdsQuery(string[] ids) => InstructorIds = ids;
        }

        public class GetLibraryContentByArrayOfInstructorIdsQueryHandler : IRequestHandler<GetLibraryContentByArrayOfInstructorIdsQuery, IEnumerable<Media>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetLibraryContentByArrayOfInstructorIdsQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.LIBRARY);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<Media>> Handle(GetLibraryContentByArrayOfInstructorIdsQuery query, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                var instructorIds = query.InstructorIds.Select(x => new KeyValuePair<string, string>("instructorId", x)).ToList();

                string uri = $"content";
                var queryString = $"{uri}{QueryString.Create(instructorIds).ToString()}";
                
                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(queryString);

                var content = await response.Content.ReadAsStringAsync();

                var media = JsonSerializer.Deserialize<IEnumerable<Media>>(content, DefaultJsonSettings.Settings);

                return media;
            }
        }
    }
}
