using DinamicAPI.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DinamicAPI.Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoCollection<BsonDocument> _collection;

        public MongoRepository(MongoDBContext context)
        {
            _collection = context.Collection;
        }

        public async Task<List<BsonDocument>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<BsonDocument?> GetByAccountIdAsync(string accountId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("accountId", accountId);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }


        public async Task InsertAsync(BsonDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task<bool> UpdateByAccountIdAsync(string accountId, BsonDocument updatedDocument)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("accountId", accountId);

            var result = await _collection.ReplaceOneAsync(filter, updatedDocument);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DeleteByAccountIdAsync(string accountId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("accountId", accountId);

            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }


    }
}
