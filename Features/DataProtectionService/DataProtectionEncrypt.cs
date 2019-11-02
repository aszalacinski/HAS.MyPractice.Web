using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace HAS.MyPractice.DataProtection
{
    public class DataProtectionEncrypt
    {
        public class DataProtectionEncryptCommand : IRequest<string>
        {
            public string Cookie { get; private set; }

            public DataProtectionEncryptCommand(string cookie) => Cookie = cookie;
        }

        public class DataProtectionEncryptCommandHandler : IRequestHandler<DataProtectionEncryptCommand, string>
        {
            private readonly IDataProtector _protector;

            public DataProtectionEncryptCommandHandler(IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
            {
                var encryptKey = configuration["MPY:ProfileMiddleware:CookieEncryption"];
                _protector = dataProtectionProvider.CreateProtector(encryptKey);
            }

            public Task<string> Handle(DataProtectionEncryptCommand request, CancellationToken cancellationToken)
            {
                return Task.Run(() => { return _protector.Protect(request.Cookie); });
            }
        }
    }
}
