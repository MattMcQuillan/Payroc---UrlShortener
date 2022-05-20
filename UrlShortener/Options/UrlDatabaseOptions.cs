namespace UrlShortener.Options
{
    public class UrlDatabaseOptions
    {
        public const string UrlDatabase = "UrlDatabase";

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
