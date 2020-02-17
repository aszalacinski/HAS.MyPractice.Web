using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HAS.MyPractice.GetMediaById;
using static HAS.MyPractice.UpdateMedia;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator) => _mediator = mediator;
        
        [BindProperty]
        public EditModelCommand Data { get; set; }

        public class EditModelCommand : IRequest<string>
        {
            public string Id { get; set; }
            [Display(Name = "Author First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Author Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Title")]
            public string Title { get; set; }
            [Display(Name = "Duration (in minutes)")]
            public long Duration { get; set; }
            [Display(Name = "Description")]
            public string Description { get; set; }
            public string FileName { get; set; }
            public string FileType { get; set; }
            public string FileExtension { get; set; }
            public long FileSize { get; set; }
            public string Url { get; set; }
            public string ProfileId { get; set; }
        }

        public async Task OnGetAsync(string c)
        {
            Profile profile = JsonSerializer.Deserialize<Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName));

            var media = await _mediator.Send(new GetMediaByIdQuery(c));

            Data = new EditModelCommand
            {
                Description = media.ContentDetails.Description,
                Duration = (media.ContentDetails.Duration / 1000 / 60),
                FileExtension = media.FileExtension,
                FileName = media.FileName,
                FileSize = media.ContentDetails.Size,
                FileType = media.FileType,
                FirstName = media.InstructorName.Split(' ')[0],
                Id = media.Id,
                LastName = media.InstructorName.Split(' ')[1],
                Title = media.ContentDetails.Title,
                ProfileId = media.InstructorId,
                Url = media.Uri.ToString()
                
            };
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            var update = await _mediator.Send(Data);

            return RedirectToPage("ContentList");
        }

        public class Validator : AbstractValidator<EditModelCommand>
        {
            public Validator()
            {
                RuleFor(m => m.Id).NotEmpty();
                RuleFor(m => m.Title).NotEmpty().Length(1, 100);
                RuleFor(m => m.Duration).GreaterThan(0);
                RuleFor(m => m.Description).NotEmpty();
                RuleFor(m => m.ProfileId).NotEmpty();
            }
        }

        public class EditModelCommandHandler : IRequestHandler<EditModelCommand, string>
        {

            private readonly IMediator _mediator;

            public EditModelCommandHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(EditModelCommand cmd, CancellationToken cancellationToken)
            {
                var result = await _mediator.Send(new UpdateMediaCommand(cmd.ProfileId, cmd.Id, cmd.Title, cmd.Description, cmd.Duration));

                if(string.IsNullOrEmpty(result))
                {
                    return string.Empty;
                }

                return result;
            }
        }

    }
}