using FluentValidation;
using HAS.MyPractice.Web.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.DataProtection.DataProtectionDecrypt;
using static HAS.MyPractice.UploadAudio;

namespace HAS.MyPractice.Web.Pages.Instructor
{
    public class UploadAudio : PageModel
    {
        private readonly IMediator _mediator;
        private readonly string _cookieName;

        public UploadAudio(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _cookieName = configuration["MPY:Cookies:ProfileMiddleware:Name"];
        }

        public async Task OnGetAsync()
        {
            Profile profile =  JsonSerializer.Deserialize<Profile>(await _mediator.Send(new DataProtectDecryptCommand(HttpContext.Request.Cookies[_cookieName])), DefaultJsonSettings.Settings);
            Data = new Command
            {
                InstructorId = profile.Id,
                FirstName = profile.PersonalDetails.FirstName ?? string.Empty,
                LastName = profile.PersonalDetails.LastName ?? string.Empty
            };
        }

        [BindProperty]
        public Command Data { get; set; }

        public class Command : IRequest<string>
        {
            [Required]
            public string InstructorId { get; set; }
            [Required]
            [Display(Name = "Author First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Author Last Name")]
            public string LastName { get; set; }
            [Required]
            [Display(Name = "Title")]
            public string Title { get; set; }
            [Required]
            [Display(Name = "Duration")]
            public int DurationInMinutes { get; set; }

            [Required]
            [Display(Name = "Content File")]
            public IFormFile File { get; set; }

            public string AccessToken { get; set; }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            Data.AccessToken = await HttpContext.GetTokenAsync("access_token");
            var mediaId = await _mediator.Send(Data);

            return Redirect($"./ContentEdit?c={mediaId}");
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(m => m.InstructorId).NotEmpty();
                RuleFor(m => m.FirstName).NotEmpty().Length(1, 50);
                RuleFor(m => m.LastName).NotEmpty().Length(1, 50);
                RuleFor(m => m.Title).NotEmpty().Length(1, 100);
                RuleFor(m => m.DurationInMinutes).GreaterThan(0);
                RuleFor(m => m.File).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, string>
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<string> Handle(Command cmd, CancellationToken cancellationToken)
            {
                var fileContent = new StreamContent(cmd.File.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = cmd.File.Length,
                        ContentType = new MediaTypeHeaderValue(cmd.File.ContentType)
                    }
                };

                var formDataContent = new MultipartFormDataContent();
                formDataContent.Add(fileContent, "media", cmd.File.FileName);
                formDataContent.Add(new StringContent(cmd.InstructorId), "instructorId");
                formDataContent.Add(new StringContent(cmd.Title), "title");
                formDataContent.Add(new StringContent(cmd.FirstName), "firstName");
                formDataContent.Add(new StringContent(cmd.LastName), "lastName");
                formDataContent.Add(new StringContent(cmd.DurationInMinutes.ToString()), "durationInMinutes");

                try
                {
                    var mediaId = await _mediator.Send(new UploadAudioCommand(formDataContent));

                    if(string.IsNullOrEmpty(mediaId))
                    {
                        return string.Empty;
                    }

                    return mediaId;

                }
                catch(Exception)
                {
                    return string.Empty;
                }
            }
        }
    }
}