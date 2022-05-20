namespace UrlShortener.MongoDb
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Url
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Original_Url")]
        public string originalUrl { get; set; }

        [BsonElement("Shortened_Url")]
        public string shortenedUrl { get; set; }

        [BsonElement("Created_Date")]
        public DateTime createdDate { get; set; }
    }
}
