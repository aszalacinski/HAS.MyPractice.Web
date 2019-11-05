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
    public class GetStudentProfiles
    {
        public class GetStudentProfilesQuery : IRequest<IEnumerable<Profile>>
        {

        }

        public class GetStudentProfileQueryHandler : IRequestHandler<GetStudentProfilesQuery,IEnumerable<Profile>>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public GetStudentProfileQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<IEnumerable<Profile>> Handle(GetStudentProfilesQuery request, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"students";

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
