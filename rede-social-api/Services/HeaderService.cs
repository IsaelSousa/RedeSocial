using MediatR;
using rede_social_application.Services;
using System.Text;

namespace rede_social_api.Services
{
    public static class HeaderService
    {

        public static string DeserializedToken(HttpRequest request)
        {
            string token = request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            Dictionary<string, string> deserializedToken = Token.Deserialize(token);
            return deserializedToken["Id"];
        }

        public static async Task<T> DeserializedPayload<T>(HttpRequest request)
        {
            var body = String.Empty;
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
                body = await reader.ReadToEndAsync();
            return EncryptionHelper.DecryptData<T>(body);
        }

    }

}
