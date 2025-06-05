using DinamicAPI.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DinamicAPI.Repositories
{
    public class DynamicRepository : IDynamicRepository
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public DynamicRepository(MongoDBContext context)
        {
            _collection = context.Collection;
        }

        public async Task<List<BsonDocument>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task InsertAsync(BsonDocument document)
        {
            await _collection.InsertOneAsync(document);
        }
    }
}
