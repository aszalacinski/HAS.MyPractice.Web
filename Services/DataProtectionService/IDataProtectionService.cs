namespace HAS.MyPractice
{
    public interface IDataProtectionService
    {
        string EncryptProfileCookie(string cookie);
        string DecryptProfileCookie(string cookie);
    }
}
