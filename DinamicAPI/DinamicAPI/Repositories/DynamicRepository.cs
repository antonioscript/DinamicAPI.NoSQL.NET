using DinamicAPI.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DinamicAPI.Repositories
{
    public class DynamicRepository : IDynamicRepository
    {
        private readonly IMongoDatabase _database;

        public DynamicRepository(MongoDBContext context)
        {
            _database = context.GetDatabase();
        }
        public async Task<List<BsonDocument>> GetAllAsync(string collectionName)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task InsertAsync(string collectionName, BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            await collection.InsertOneAsync(document);
        }
    }
}
