using System.Text.Json;

namespace HAS.MyPractice
{
    public static class DefaultJsonSettings
    {
        public static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
}
