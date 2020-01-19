using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.Web.Features.InviteUser.GatedRegistration
{
    public class GenerateRandomEntryCode
    {
        public class GenerateRandomEntryCodeQuery : IRequest<string>
        {
            public int Length { get; private set; }

            public GenerateRandomEntryCodeQuery(int length) => Length = length;
        }

        public class GenerateRandomEntryCodeQueryHandler : IRequestHandler<GenerateRandomEntryCodeQuery, string>
        {
            private static Random _random = new Random();

            public GenerateRandomEntryCodeQueryHandler() { }
            
            public Task<string> Handle(GenerateRandomEntryCodeQuery query, CancellationToken cancellationToken)
            {
                const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

                var code = new string(Enumerable.Range(1, query.Length).Select(_ => chars[_random.Next(chars.Length)]).ToArray());

                return Task.FromResult(code);
            }
        }
    }
}
