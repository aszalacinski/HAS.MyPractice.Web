using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetMediaById;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class PlayerModel : PageModel
    {
        private readonly IMediator _mediator;

        public MediaFile Media { get; private set; }

        public PlayerModel(IMediator mediator) => _mediator = mediator;

        public async Task OnGetAsync(string d)
        {
            var media = await _mediator.Send(new GetMediaByIdQuery(d));

            Media = new MediaFile
            {
                Author = media.InstructorName,
                Description = media.ContentDetails.Description,
                Uri = media.Uri.ToString(),
                Title = media.ContentDetails.Title,
                Id = media.Id
            };
        }

        public class MediaFile
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string Uri { get; set; }
        }

    }
}