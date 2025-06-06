using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using DinamicAPI.Data;
using System.Text.Json;

namespace DinamicAPI.Repositories;
public class DynamoRepository : IDynamoRepository
{
    private readonly IAmazonDynamoDB _client;
    const string _tableName = "DinamicDB";

    public DynamoRepository(IAmazonDynamoDB client)
    {
        _client = client;
    }

    public async Task InsertAsync(JsonElement document)
    {
        var doc = Document.FromJson(document.GetRawText());
        var table = Table.LoadTable(_client, _tableName);

        await table.PutItemAsync(doc);
    }

    public async Task<JsonElement?> GetByAccountIdAsync(string accountId)
    {
        var table = Table.LoadTable(_client, _tableName);
        var doc = await table.GetItemAsync(accountId);

        return doc != null ? JsonSerializer.Deserialize<JsonElement>(doc.ToJson()) : null;
    }
}
