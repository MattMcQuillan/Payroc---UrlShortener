namespace UrlShortener.MongoDb
{
    public interface IUrlDal
    {
        public Url getUrlByShortenedUrl(string shortenedUrl);

        public Url returnUrlIfPresent(string originalUrl);

        public Url addUrl(Url url);
    }
}
