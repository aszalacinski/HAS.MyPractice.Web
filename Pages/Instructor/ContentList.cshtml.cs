using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static HAS.MyPractice.GetAllMediaByProfileId;
using static HAS.MyPractice.GetAllMediaInDefaultLibrary;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator) => _mediator = mediator;
        
        [BindProperty]
        public QueryResult Data { get; set; }


        public class QueryResult
        {
            public IEnumerable<Media> All { get; set; }
            public IEnumerable<Media> Shared { get; set; }

        }

        public async Task OnGetAsync()
        {
            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            var getAll = await _mediator.Send(new GetAllMediaByProfileIDQuery(profile.Id));
            var getShared = await _mediator.Send(new GetAllMediaInDefaultLibraryQuery(profile.Id));

            Data = new QueryResult 
            {
                All = getAll,
                Shared = getShared
            };  
        }

    }
}