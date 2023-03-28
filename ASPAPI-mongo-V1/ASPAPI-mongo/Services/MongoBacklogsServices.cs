using ASPAPI_mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ASPAPI_mongo.Services
{
    public class MongoBacklogsServices
    {
        private readonly IMongoCollection<MongoBacklog> _backlogsCollection;
        public MongoBacklogsServices(
            IOptions<BacklogDatabaseSettings> backlogDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            backlogDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
            backlogDatabaseSettings.Value.DatabaseName);
            _backlogsCollection = mongoDatabase.GetCollection<MongoBacklog>(
            backlogDatabaseSettings.Value.BacklogsCollectionName);
        }
        public async Task<List<MongoBacklog>> GetAsync() =>
        await _backlogsCollection.Find(_ => true).ToListAsync();
        public async Task<MongoBacklog?> GetAsync(string id) =>
        await _backlogsCollection.Find(x => x.backlogID == id).FirstOrDefaultAsync();
        public async Task CreateAsync(MongoBacklog newBacklog) =>
        await _backlogsCollection.InsertOneAsync(newBacklog);
        public async Task UpdateAsync(string id, MongoBacklog updatedBacklog) =>
        await _backlogsCollection.ReplaceOneAsync(x => x.backlogID == id, updatedBacklog);
        public async Task RemoveAsync(string id) =>
        await _backlogsCollection.DeleteOneAsync(x => x.backlogID == id);
    }
}