using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using rede_social_application.Commands.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Services
{
    public static class EncryptionHelper
    {
        private static string key = "09671b9c34e44f28";

        public static T DecryptData<T>(string data)
        {
            byte[] iV = new byte[16];
            byte[] buffer = Convert.FromBase64String(data);
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iV;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;
            ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream stream = new MemoryStream(buffer);
            using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            using StreamReader streamReader = new StreamReader(stream2);
            return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
        }
    }
}
