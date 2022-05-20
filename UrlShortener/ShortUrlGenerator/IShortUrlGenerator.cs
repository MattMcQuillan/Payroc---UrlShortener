namespace UrlShortener.ShortUrlGenerator
{
    public interface IShortUrlGenerator
    {
        public string generate(string url);
    }
}
