namespace UrlShortener.Services
{
    using System;
    using UrlShortener.MongoDb;
    using UrlShortener.ShortUrlGenerator;

    public class UrlService : IUrlService
    {
        private readonly IUrlDal _dal;
        private readonly IShortUrlGenerator _shortUrlGenerator;

        public UrlService(IUrlDal urlDal, IShortUrlGenerator shortUrlGenerator)
        {
            _dal = urlDal;
            _shortUrlGenerator = shortUrlGenerator;
        }

        public Url getUrlByShortenedUrl(string shortenedUrl)
        {
            return _dal.getUrlByShortenedUrl(shortenedUrl);
        }

        public Url shortenUrl(string originalUrl)
        {
            Url returnUrl = null;
            returnUrl = _dal.returnUrlIfPresent(originalUrl);

            if(returnUrl != null)
            {
                return returnUrl;
            }

            returnUrl = new Url();
            returnUrl.shortenedUrl = _shortUrlGenerator.generate(originalUrl);
            returnUrl.originalUrl = originalUrl;
            returnUrl.createdDate = DateTime.UtcNow;

            return _dal.addUrl(returnUrl);
        }
    }
}
