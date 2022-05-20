using System;
using Moq;
using NUnit.Framework;
using UrlShortener.MongoDb;
using UrlShortener.Services;
using UrlShortener.ShortUrlGenerator;

namespace UrlShortenerTest
{
    public class UrlServiceTest
    {
        private UrlService _service;

        [Test]
        public void shortenUrl_ReturnsExistingUrlIfAlreadyPresent()
        {
            var mockUrlDal = new Mock<IUrlDal>();
            ShortUrlGenerator shortUrlGenerator = new ShortUrlGenerator();
            Url url = new Url()
            {
                shortenedUrl = "Xdf6gn"
            };

            mockUrlDal.Setup(x => x.returnUrlIfPresent("www.google.com")).Returns(url);

            _service = new UrlService(mockUrlDal.Object, shortUrlGenerator);

            var result = _service.shortenUrl("www.google.com");

            Assert.AreEqual(result.shortenedUrl, url.shortenedUrl);
        }
    }
}
