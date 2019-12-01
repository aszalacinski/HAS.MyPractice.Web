using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice
{
    public class UpdateProfileToInstructor
    {
        public class UpdateProfileToInstructorCommand : IRequest<Profile>
        {
            public string ProfileId { get; private set; }
            public string PublicName { get; private set; }
            public UpdateProfileToInstructorCommand(string profileId, string publicName)
            {
                ProfileId = profileId;
                PublicName = publicName;
            }
        }

        public class UpdateProfileToInstructorCommandHandler : IRequestHandler<UpdateProfileToInstructorCommand, Profile>
        {
            private readonly IHttpContextAccessor _httpContextAcessor;
            private readonly HttpClient _httpClient;

            public UpdateProfileToInstructorCommandHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient(HASClientFactories.PROFILE);
                _httpContextAcessor = httpContextAccessor;
            }

            public async Task<Profile> Handle(UpdateProfileToInstructorCommand cmd, CancellationToken cancellationToken)
            {
                var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                string uri = $"{cmd.ProfileId}/as/in";

                _httpClient.SetBearerToken(accessToken);

                var payload = new { cmd.PublicName };

                var json = JsonSerializer.Serialize(payload, DefaultJsonSettings.Settings);

                var putContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(uri, putContent);
                
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new InstructorPublicNameException(content);
                }
                
                return JsonSerializer.Deserialize<Profile>(content, DefaultJsonSettings.Settings);
            }
        }
    }

    public class InstructorPublicNameException : Exception
    {
        public InstructorPublicNameException() { }

        public InstructorPublicNameException(string message)
            : base(message) { }

        public InstructorPublicNameException(string message, Exception inner)
            : base(message, inner) { }
    }
}
