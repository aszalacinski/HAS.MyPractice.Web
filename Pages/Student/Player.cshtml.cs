using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class PlayerModel : PageModel
    {
        private readonly IMediator _mediator;

        public GetMediaForPlayerResult Media { get; private set; }

        public PlayerModel(IMediator mediator) => _mediator = mediator;

        public async Task OnGetAsync(string d)
        {
            Media = await _mediator.Send(new GetMediaForPlayerQuery(d));
        }

        public class GetMediaForPlayerQuery : IRequest<GetMediaForPlayerResult>
        {
            public string MediaId { get; private set; }

            private GetMediaForPlayerQuery() { }

            public GetMediaForPlayerQuery(string mediaId)
            {
                MediaId = mediaId;
            }
        }

        public class GetMediaForPlayerResult
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string MediaUri { get; set; }
        }

        public class GetMediaForPlayerQueryHandler : IRequestHandler<GetMediaForPlayerQuery, GetMediaForPlayerResult>
        {
            private readonly MapperConfiguration _mapperConfiguration;

            public GetMediaForPlayerQueryHandler()
            {
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    //cfg.CreateMap<MediaFile, GetMediaForPlayerResult>();

                });
            }

            public Task<GetMediaForPlayerResult> Handle(GetMediaForPlayerQuery request, CancellationToken cancellationToken)
            {
                var result = new GetMediaForPlayerResult
                {
                    Id = "9999999999999999",
                    Author = "Aarron Szalacinski",
                    Description = "Demo file that shows impressive use of a new media player.",
                    Title = "Demo Media Audio File",
                    MediaUri = "~/audio/BalanceClass.m4a"
                };

                return Task.FromResult(result);
            }
        }
    }
}