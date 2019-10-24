using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HAS.MyPractice.Web.Model.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HAS.MyPractice.Web.Pages.Student
{
    public class LibraryModel : PageModel
    {
        private readonly IMediator _mediator;

        public GetLibraryMediaForUserResult Thumbnails { get; private set; }

        public LibraryModel(IMediator mediator) => _mediator = mediator;

        public async Task OnGetAsync()
        {
            string userId = "0000000000000000000000";

            Thumbnails = await _mediator.Send(new GetLibraryMediaForUserQuery(userId));
        }

        public class GetLibraryMediaForUserQuery : IRequest<GetLibraryMediaForUserResult> 
        { 
            public string UserProfileId { get; private set; }

            private GetLibraryMediaForUserQuery() { }

            public GetLibraryMediaForUserQuery(string userProfileId)
            {
                UserProfileId = userProfileId;
            }
        }

        public class GetLibraryMediaForUserResult
        {
            public List<MediaThumbnail> Media { get; set; }

            public class MediaThumbnail
            {
                public string Id { get; set; }
                public long Duration { get; set; }
                public string Title { get; set; }
                public string Author { get; set; }
            }
        }

        public class GetLibraryMediaForUserQueryHandler : IRequestHandler<GetLibraryMediaForUserQuery, GetLibraryMediaForUserResult>
        {
            private readonly MapperConfiguration _mapperConfiguration;

            public GetLibraryMediaForUserQueryHandler()
            {
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MediaFile, GetLibraryMediaForUserResult.MediaThumbnail>();

                });
            }

            public Task<GetLibraryMediaForUserResult> Handle(GetLibraryMediaForUserQuery request, CancellationToken cancellationToken)
            {

                var mapper = new Mapper(_mapperConfiguration);

                var files = new List<MediaFile>
                {
                    new MediaFile
                    {
                        Id = "111111111111111",
                        Author = "Aarron Szalacinski",
                        Duration = 100,
                        Title = "First Demo file"
                    },

                    new MediaFile
                    {
                        Id = "222222222222222",
                        Author = "Aarron Szalacinski",
                        Duration = 120,
                        Title = "Second Demo file"
                    },

                    new MediaFile
                    {
                        Id = "3333333333333333",
                        Author = "Aarron Szalacinski",
                        Duration = 75,
                        Title = "Third Demo file"
                    },

                    new MediaFile
                    {
                        Id = "444444444444444",
                        Author = "Aarron Szalacinski",
                        Duration = 95,
                        Title = "Fourth Demo file"
                    },

                    new MediaFile
                    {
                        Id = "5555555555555555",
                        Author = "Aarron Szalacinski",
                        Duration = 72,
                        Title = "Fifth Demo file"
                    },

                    new MediaFile
                    {
                        Id = "666666666666666",
                        Author = "Aarron Szalacinski",
                        Duration = 45,
                        Title = "Sixth Demo file"
                    },

                    new MediaFile
                    {
                        Id = "777777777777777",
                        Author = "Aarron Szalacinski",
                        Duration = 33,
                        Title = "Seventh Demo file"
                    },

                    new MediaFile
                    {
                        Id = "8888888888888888",
                        Author = "Aarron Szalacinski",
                        Duration = 15,
                        Title = "Eigth Demo file"
                    },
                };

                var result = new GetLibraryMediaForUserResult();
                result.Media = new List<GetLibraryMediaForUserResult.MediaThumbnail>();

                foreach (var file in files)
                {
                    var thumb = new GetLibraryMediaForUserResult.MediaThumbnail()
                    {
                        Id = file.Id,
                        Author = file.Author,
                        Duration = file.Duration,
                        Title = file.Title
                    };

                    result.Media.Add(thumb);
                }

                return Task.FromResult(result);
            }
        }
    }
}