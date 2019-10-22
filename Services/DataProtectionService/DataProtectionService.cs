using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

namespace HAS.MyPractice
{
    public class DataProtectionService : IDataProtectionService
    {
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;

        public DataProtectionService(IConfiguration configuration, IDataProtectionProvider dataProtectionProvider)
        {
            _configuration = configuration;
            var encryptKey = _configuration.GetSection("MPY:ProfileMiddleware:CookieEncryption").Value;

            _protector = dataProtectionProvider.CreateProtector(encryptKey);
        }
        public string EncryptProfileCookie(string cookie)
        {
            return _protector.Protect(cookie);
        }

        public string DecryptProfileCookie(string cookie)
        {
            return _protector.Unprotect(cookie);
        }
    }
}
