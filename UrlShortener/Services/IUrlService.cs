namespace UrlShortener.Services
{
    using UrlShortener.MongoDb;

    public interface IUrlService
    {
        public Url shortenUrl(string originalUrl);

        public Url getUrlByShortenedUrl(string shortenedUrl);
    }
}
