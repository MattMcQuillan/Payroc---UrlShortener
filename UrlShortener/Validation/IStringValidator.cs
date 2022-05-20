namespace UrlShortener.Validation
{
    public interface IStringValidator
    {
        public void inputUrlValidation(string originalUrl);

        public void shortenedUrlValidation(string shortenedUrl);
    }
}
