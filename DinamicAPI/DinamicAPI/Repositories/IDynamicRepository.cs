using MongoDB.Bson;

namespace DinamicAPI.Repositories
{
    public interface IDynamicRepository
    {
        Task<List<BsonDocument>> GetAllAsync();

        Task InsertAsync(BsonDocument document);
    }
}
