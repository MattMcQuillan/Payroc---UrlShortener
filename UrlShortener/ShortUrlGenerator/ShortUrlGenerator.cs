namespace UrlShortener.ShortUrlGenerator
{
    using System.Security.Cryptography;
    using System.Text;
    using Microsoft.AspNetCore.WebUtilities;

    public class ShortUrlGenerator : IShortUrlGenerator
    { 
        public string generate(string url)
        {
            MD5 md5Hash = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(url);
            byte[] hashBytes = md5Hash.ComputeHash(inputBytes);

            return WebEncoders.Base64UrlEncode(hashBytes).Substring(0, 6);
        }
    }
}
