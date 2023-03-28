using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ASPAPI_mongo.Models
{
    public class MongoBacklog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? backlogID { get; set; }
        public string Title { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public bool Finished { get; set; }
    }
}
