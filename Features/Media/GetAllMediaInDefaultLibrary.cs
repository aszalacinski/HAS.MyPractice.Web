using HAS.MyPractice.Web.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.GetHubByProfileId;
using static HAS.MyPractice.GetLibraryByName;
using static HAS.MyPractice.GetLibraryContent;
using static HAS.MyPractice.GetMediaByArrayOfIds;

namespace HAS.MyPractice
{
    public class GetAllMediaInDefaultLibrary
    {
        public class GetAllMediaInDefaultLibraryQuery : IRequest<IEnumerable<Media>>
        {
            public string ProfileId { get; private set; }

            public GetAllMediaInDefaultLibraryQuery(string profileId) => ProfileId = profileId;
        }

        public class GetAllMediaInDefaultLibraryQueryHandler : IRequestHandler<GetAllMediaInDefaultLibraryQuery, IEnumerable<Media>>
        {
            private readonly IMediator _mediator;

            public GetAllMediaInDefaultLibraryQueryHandler(IMediator mediator) => _mediator = mediator;

            public async Task<IEnumerable<Media>> Handle(GetAllMediaInDefaultLibraryQuery query, CancellationToken cancellationToken)
            {
                var hub = await _mediator.Send(new GetHubByProfileIdQuery(query.ProfileId));
                var library = await _mediator.Send(new GetLibraryByNameQuery(query.ProfileId, $"Default-{query.ProfileId}"));

                string hubId = hub.Id;
                string libraryId = library.Id;

                IEnumerable<Content> content = await _mediator.Send(new GetLibraryContentQuery(hubId, libraryId));

                var contentIds = content.Select(x => x.Id).ToArray();

                IEnumerable<Media> media = await _mediator.Send(new GetMediaByArrayOfIdsQuery(contentIds));

                return media;

            }

        }
    }
}
