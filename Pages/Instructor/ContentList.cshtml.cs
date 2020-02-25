using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static HAS.MyPractice.AddMediaToLibrary;
using static HAS.MyPractice.DeleteContentFromLibrary;
using static HAS.MyPractice.GetAllMediaByProfileId;
using static HAS.MyPractice.GetAllMediaInDefaultLibrary;
using static HAS.MyPractice.GetHubByProfileId;
using static HAS.MyPractice.GetLibraryByName;

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
            public IEnumerable<Media> NotShared { get; set; }
            public string HubId { get; set; }
            public string LibraryId { get; set; }

        }

        public async Task OnGetAsync()
        {
            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            var hub = await _mediator.Send(new GetHubByProfileIdQuery(profile.Id));
            var defaultLib = await _mediator.Send(new GetLibraryByNameQuery(profile.Id, $"Default-{profile.Id}"));
            var getAll = await _mediator.Send(new GetAllMediaByProfileIDQuery(profile.Id));
            var getShared = await _mediator.Send(new GetAllMediaInDefaultLibraryQuery(profile.Id));

            var sharedIds = getShared.Select(c => c.Id).ToList();
            var notShared = getAll.Where(f => !sharedIds.Contains(f.Id)).ToList();

            Data = new QueryResult
            {
                HubId = hub.Id,
                LibraryId = defaultLib.Id,
                All = getAll.OrderByDescending(x => x.RecordingDate),
                Shared = getShared.OrderByDescending(x => x.RecordingDate),
                NotShared = notShared.OrderByDescending(x => x.RecordingDate)
            };  
        }

        public async Task<IActionResult> OnPostMoveAsync(string hubId, string libraryId, string fileId)
        {
            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            var moved = await _mediator.Send(new AddMediaToLibraryCommand(profile.Id, hubId, libraryId, fileId));

            return RedirectToPage("ContentList");
        }

        public async Task<IActionResult> OnPostRemoveAsync(string hubId, string libraryId, string fileId)
        {
            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            var removed = await _mediator.Send(new DeleteContentFromLibraryCommand(profile.Id, hubId, libraryId, fileId));

            return RedirectToPage("ContentList");

        }
    }
}