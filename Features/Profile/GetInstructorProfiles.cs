using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class GetInstructorProfiles
    {
        public class GetInstructorProfilesQuery : IRequest<IEnumerable<Profile>>
        {

        }

        public class GetInstructorProfilesQueryHandler : IRequestHandler<GetInstructorProfilesQuery, IEnumerable<Profile>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetInstructorProfilesQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<Profile>> Handle(GetInstructorProfilesQuery request, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"instructors";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.GetAsync(uri);

                if (response.StatusCode.Equals(HttpStatusCode.NoContent))
                {
                    return JsonSerializer.Deserialize<IEnumerable<Profile>>("[]", DefaultJsonSettings.Settings);
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<IEnumerable<Profile>>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
