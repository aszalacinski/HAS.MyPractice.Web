using HAS.MyPractice.Web.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static HAS.MyPractice.GetLibraryContentByArrayOfInstructorIds;
using static HAS.MyPractice.GetSubscriptionsByProfileId;

namespace HAS.MyPractice
{
    public class ObtainAllSubscribedMedia
    {
        public class ObtainAllSubscribedMediaQuery : IRequest<IEnumerable<Media>>
        {
            public string ProfileId { get; private set; }

            public ObtainAllSubscribedMediaQuery(string profileId) => ProfileId = profileId;
        }

        public class ObtainAllSubscribedMediaQueryHandler : IRequestHandler<ObtainAllSubscribedMediaQuery, IEnumerable<Media>>
        {
            private readonly IMediator _mediator;

            public ObtainAllSubscribedMediaQueryHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<IEnumerable<Media>> Handle(ObtainAllSubscribedMediaQuery query, CancellationToken cancellationToken)
            {

                // get all subscribed instructor ids
                var ids = await _mediator.Send(new GetSubscriptionsByProfileIdQuery(query.ProfileId));

                // get all content from instructors
                var media = await _mediator.Send(new GetLibraryContentByArrayOfInstructorIdsQuery(ids));

                return media;
            }

        }

    }
}
