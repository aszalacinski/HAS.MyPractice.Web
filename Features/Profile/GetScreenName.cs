using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Features.Profile
{
    public class GetScreenName
    {
        public class GetScreenNameQuery : IRequest<string>
        {
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }

            public GetScreenNameQuery(string firstname, string lastname, string email)
            {
                FirstName = firstname;
                LastName = lastname;
                Email = email;
            }
        }

        public class GetScreenNameQueryHandler : IRequestHandler<GetScreenNameQuery, string>
        {
            public Task<string> Handle(GetScreenNameQuery query, CancellationToken cancellationToken)
            {
                string screenName = string.Empty;

                if (!string.IsNullOrEmpty(query.FirstName) && !string.IsNullOrEmpty(query.LastName))
                {
                    screenName = $"{query.FirstName[0]}{query.LastName}";
                }
                else if (!string.IsNullOrEmpty(query.FirstName) && string.IsNullOrEmpty(query.LastName))
                {
                    screenName = $"{query.FirstName}";
                }
                else if (string.IsNullOrEmpty(query.FirstName) && !string.IsNullOrEmpty(query.LastName))
                {
                    screenName = $"{query.LastName}";
                }
                else
                {
                    screenName = $"{query.Email.Split('@')[0]}";
                }

                return Task.FromResult(screenName);
            }
        }
    }
}
