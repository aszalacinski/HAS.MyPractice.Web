using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static HAS.MyPractice.ObtainAllSubscribedMedia;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class LibraryModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly MapperConfiguration _mapperConfiguration;

        public IEnumerable<Thumbnail> Data { get; private set; }

        public LibraryModel(IMediator mediator) 
        {
            _mediator = mediator;
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Media, Thumbnail>()
                    .ForMember(m => m.Author, opt => opt.MapFrom(src => src.InstructorName))
                    .ForMember(m => m.Duration, opt => opt.MapFrom(src => src.ContentDetails.Duration))
                    .ForMember(m => m.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(m => m.Title, opt => opt.MapFrom(src => src.ContentDetails.Title))
                    .ForMember(m => m.Date, opt => opt.MapFrom(src => src.RecordingDate));
            });
        }

        public async Task OnGetAsync()
        {
            var mapper = new Mapper(_mapperConfiguration);

            Model.Profile profile = JsonSerializer.Deserialize<Model.Profile>(HttpContext.Session.GetString(HASSessionKeys.SessionKeyProfileName), DefaultJsonSettings.Settings);

            var media = await _mediator.Send(new ObtainAllSubscribedMediaQuery(profile.Id));

            Data = mapper.Map<IEnumerable<Thumbnail>>(media);
        }
        
        public class Thumbnail
        {
            public string Id { get; set; }
            public long Duration { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime Date { get; set; }
        }

    }
}