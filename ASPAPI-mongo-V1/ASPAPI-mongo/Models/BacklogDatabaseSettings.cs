namespace ASPAPI_mongo.Models
{
    public class BacklogDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BacklogsCollectionName { get; set; } = null!;
    }
}