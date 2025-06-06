using System.Text.Json;

namespace DinamicAPI.Repositories;
public interface IDynamoRepository
{
    Task InsertAsync(JsonElement document);
    Task<JsonElement?> GetByAccountIdAsync(string accountId);
}