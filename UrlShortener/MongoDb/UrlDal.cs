namespace UrlShortener.MongoDb
{
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using UrlShortener.Options;

    public class UrlDal : IUrlDal
    { 
        private readonly IMongoDatabase _db;
        private UrlDatabaseOptions _options;

        public UrlDal(IOptions<UrlDatabaseOptions> options)
        {
            _options = options.Value;
            var client = new MongoClient(_options.ConnectionString);
            _db = client.GetDatabase(_options.DatabaseName);
        }

        public Url addUrl(Url url)
        {
            try
            {
                _db.GetCollection<Url>(_options.CollectionName).InsertOne(url);
                return url;
            }
            catch 
            {
                return null;
            }
        }

        public Url getUrlByShortenedUrl(string shortenedUrl)
        {
            Url returnedUrl = null;
            if (!string.IsNullOrEmpty(shortenedUrl))
            {
                returnedUrl = _db.GetCollection<Url>(_options.CollectionName).Find<Url>(url => url.shortenedUrl == shortenedUrl).FirstOrDefault();
            }

            return returnedUrl;
        }

        public Url returnUrlIfPresent(string originalUrl)
        {
            bool isPresent = false;
            if (!string.IsNullOrEmpty(originalUrl))
            {
                isPresent = _db.GetCollection<Url>(_options.CollectionName).Find<Url>(url => url.originalUrl == originalUrl).Any();
            }

            if (isPresent)
            {
                return _db.GetCollection<Url>(_options.CollectionName).Find<Url>(url => url.originalUrl == originalUrl).FirstOrDefault();
            }

            return null;
        }
    }
}
