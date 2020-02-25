using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HAS.MyPractice.Web.Model;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.Web.ListStudentsModel.GetInstructorDefaultTribe;
using static HAS.MyPractice.Web.ListStudentsModel.GetStudentsOfTribe;
using static HAS.MyPractice.Web.ListStudentsModel.GetStudentsOfTribe.GetStudentOfTribeQueryHandler;

namespace HAS.MyPractice.Web
{
    public class ListStudentsModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListStudentsModel(IMediator mediator) => _mediator = mediator;

        [BindProperty]
        public QueryResult Data { get; set; }

        public class QueryResult
        {
            public string InstructorId { get; set; }
            public IEnumerable<MiniProfileResult> Students { get; set; }
        }

        public async Task OnGetAsync()
        {
            Profile instructorProfile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            // get default tribe for instructor, need the list of tribe members
            var tribe = await _mediator.Send(new GetInstructorDefaultTribeQuery(instructorProfile.Id));

            // using the tribe member id's, get the student profiles
            var students = await _mediator.Send(new GetStudentsOfTribeQuery(tribe.Id));

            QueryResult qr = new QueryResult
            {
                InstructorId = instructorProfile.Id,
                Students = students
            };

            Data = qr;
        }

        public class GetInstructorDefaultTribe
        {
            public class GetInstructorDefaultTribeQuery : IRequest<Tribe>
            {
                public string InstructorId { get; private set; }

                public GetInstructorDefaultTribeQuery(string instructorId) => InstructorId = instructorId;
            }

            public class GetInstructorDefaultTribeQueryHandler : IRequestHandler<GetInstructorDefaultTribeQuery, Tribe>
            {
                private readonly IHttpContextAccessor _httpContextAcessor;
                private readonly HttpClient _httpClient;

                public GetInstructorDefaultTribeQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
                {
                    _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                    _httpContextAcessor = httpContextAccessor;
                }

                public async Task<Tribe> Handle(GetInstructorDefaultTribeQuery query, CancellationToken cancellationToken)
                {
                    var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                    string uri = $"{query.InstructorId}/a";

                    _httpClient.SetBearerToken(accessToken);

                    var response = await _httpClient.GetAsync(uri);

                    if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        return null;
                    }

                    var content = await response.Content.ReadAsStringAsync();

                    var tribes = JsonSerializer.Deserialize<IEnumerable<Tribe>>(content, DefaultJsonSettings.Settings);

                    if(tribes.Count() <= 0)
                    {
                        return null;
                    }

                    var tribe = tribes.ToList().Where(x => x.Name.Contains($"Default-{query.InstructorId}")).FirstOrDefault();

                    return tribe;
                }
            }
        }

        public class GetStudentsOfTribe
        {
            public class GetStudentsOfTribeQuery : IRequest<IEnumerable<MiniProfileResult>>
            {
                public string TribeId { get; private set; }

                public GetStudentsOfTribeQuery(string tribeId) => TribeId = tribeId;
            }

            public class GetStudentOfTribeQueryHandler : IRequestHandler<GetStudentsOfTribeQuery, IEnumerable<MiniProfileResult>>
            {
                private readonly IHttpContextAccessor _httpContextAcessor;
                private readonly HttpClient _httpClient;

                public GetStudentOfTribeQueryHandler(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
                {
                    _httpClient = httpClientFactory.CreateClient(HASClientFactories.TRIBE);
                    _httpContextAcessor = httpContextAccessor;
                }

                public async Task<IEnumerable<MiniProfileResult>> Handle(GetStudentsOfTribeQuery query, CancellationToken cancellationToken)
                {
                    var accessToken = await _httpContextAcessor.HttpContext.GetTokenAsync("access_token");

                    string uri = $"{query.TribeId}/stu";

                    _httpClient.SetBearerToken(accessToken);

                    var response = await _httpClient.GetAsync(uri);

                    if (response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        return null;
                    }

                    var content = await response.Content.ReadAsStringAsync();

                    var students = JsonSerializer.Deserialize<IEnumerable<MiniProfileResult>>(content, DefaultJsonSettings.Settings);

                    if (students.Count() <= 0)
                    {
                        return null;
                    }

                    return students;
                }

                public class MiniProfileResult
                {
                    public string Id { get; set; }
                    public DateTime lastUpdate { get; set; }
                    public DateTime JoinDate { get; set; }
                    public DateTime LastLogin { get; set; }
                    public PersonalDetails PersonalDetails { get; set; }
                }

                public class PersonalDetails
                {
                    public string UserId { get; set; }
                    public string Email { get; set; }
                    public string ScreenName { get; set; }
                    public string FirstName { get; set; }
                    public string LastName { get; set; }
                    public LocationDetails Location { get; set; }
                }

                public class LocationDetails
                {
                    public string Country { get; set; }
                    public string City { get; set; }
                    public string StateProvince { get; set; }
                }
            }
        }
    }
}