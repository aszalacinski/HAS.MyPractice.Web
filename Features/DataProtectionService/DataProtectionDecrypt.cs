using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.DataProtection
{
    public class DataProtectionDecrypt
    {
        public class DataProtectDecryptCommand : IRequest<string>
        {
            public string Cookie { get; private set; }

            public DataProtectDecryptCommand(string cookie) => Cookie = cookie;
        }

        public class DataProtectDecryptCommandHandler : IRequestHandler<DataProtectDecryptCommand, string>
        {
            private readonly IDataProtector _protector;

            public DataProtectDecryptCommandHandler(IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
            {
                var encryptKey = configuration["MPY:ProfileMiddleware:CookieEncryption"];
                _protector = dataProtectionProvider.CreateProtector(encryptKey);
            }

            public Task<string> Handle(DataProtectDecryptCommand request, CancellationToken cancellationToken)
            {
                return Task.Run(() => { return _protector.Unprotect(request.Cookie); });
            }
        }
    }
}
