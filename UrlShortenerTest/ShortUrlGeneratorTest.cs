using System.Text.RegularExpressions;
using NUnit.Framework;
using UrlShortener.ShortUrlGenerator;

namespace UrlShortenerTest
{
    public class ShortUrlGeneratorTest
    {
        ShortUrlGenerator generator;
        private const string shortenedUrlRegex = @"[A-Za-z0-9+\/{6}]";
        Regex regex = new Regex(shortenedUrlRegex);

        [SetUp]
        public void Setup()
        {
            generator = new ShortUrlGenerator();
        }

        [TestCase("http://www.something.com")]
        [TestCase("http://www.me.jp")]
        [TestCase("https://www.something.com/somethingelse?newstuff")]
        [TestCase("https://www.thisisaverylongurlforthepurposeofvalidationthatthelengthdoesnotpresentaproblem/hopefullyItdoesnt/itDefinitelyShouldnt/Itshouldtheoreticallybegrand")]
        public void UrlsOfVaryingLength_ReturnCorrectFormatShortenedUrl(string input)
        {
            var output = generator.generate(input);
            Assert.True(output.Length == 6);
            Assert.True(regex.IsMatch(output));
        }

    }
}
