using System.Security.Cryptography;

namespace MessageService.Services
{
    public class GetSecurityKey
    {
        public static RSA GetKey(string filename)
        {
            var file = File.ReadAllText($"rsa/{filename}");

            var rsa = RSA.Create();
            rsa.ImportFromPem(file);
            return rsa;
        }
    }
}
