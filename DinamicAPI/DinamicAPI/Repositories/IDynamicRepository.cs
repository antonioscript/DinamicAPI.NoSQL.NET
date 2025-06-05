using MongoDB.Bson;

namespace DinamicAPI.Repositories;

public interface IDynamicRepository
{
    Task<List<BsonDocument>> GetAllAsync(string collectionName);
    Task InsertAsync(string collectionName, BsonDocument document);
}
