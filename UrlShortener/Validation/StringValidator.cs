namespace UrlShortener.Validation
{
    using System;
    using System.Text.RegularExpressions;

    public class StringValidator : IStringValidator
    {
        private const string urlRegex = @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

        private const string shortenedUrlRegex = @"[A-Za-z0-9+\/{6}]";

        public void inputUrlValidation(string originalUrl)
        {
            Regex regex = new Regex(urlRegex);
            if (regex.IsMatch(originalUrl))
            {
                return;
            }

            throw new ArgumentException("String was not a valid Url.");
        }

        public void shortenedUrlValidation(string shortenedUrl)
        {
            Regex regex = new Regex(shortenedUrlRegex);
            if (regex.IsMatch(shortenedUrl))
            {
                return;
            }

            throw new ArgumentException("String was not a valid Url.");
        }
    }
}
