using MongoDB.Bson;

namespace DinamicAPI.Repositories
{
    public interface IDynamicRepository
    {
        Task<List<BsonDocument>> GetAllAsync();
        Task<BsonDocument?> GetByAccountIdAsync(string accountId);
        Task InsertAsync(BsonDocument document);
        Task<bool> UpdateByAccountIdAsync(string accountId, BsonDocument updatedDocument);
        Task<bool> DeleteByAccountIdAsync(string accountId);

    }
}
