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
    public class AddStudentToTribe
    {
        public class AddStudentToTribeCommand : IRequest<Tribe>
        {
            public string InstructorId { get; private set; }
            public string TribeId { get; private set; }
            public string StudentId { get; private set; }

            public AddStudentToTribeCommand(string instructorId, string tribeId, string studentId)
            {
                InstructorId = instructorId;
                TribeId = tribeId;
                StudentId = studentId;
            }
        }

        public class AddStudentToTribeCommandHandler : IRequestHandler<AddStudentToTribeCommand, Tribe>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public AddStudentToTribeCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Tribe> Handle(AddStudentToTribeCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.InstructorId}/{cmd.TribeId}/a/{cmd.StudentId}";

                _httpClient.SetBearerToken(accessToken);

                var response = await _httpClient.PutAsync(uri, null);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Tribe>(content, DefaultJsonSettings.Settings);
            }
        }
    }
}
