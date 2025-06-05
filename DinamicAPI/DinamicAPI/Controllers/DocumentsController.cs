using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using DinamicAPI.Repositories;
using System.Text.Json;

namespace DinamicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDynamicRepository _repository;

        public DocumentsController(IDynamicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var docs = await _repository.GetAllAsync();

                var jsonList = docs
                    .Select(d => JsonSerializer.Deserialize<object>(d.ToJson()))
                    .ToList();

                return Ok(jsonList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao recuperar documentos.", details = ex.Message });
            }
        }


        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetByAccountId(string accountId)
        {
            try
            {
                var document = await _repository.GetByAccountIdAsync(accountId);

                if (document == null)
                    return NotFound(new { message = "Account not found." });

                var json = JsonSerializer.Deserialize<object>(document.ToJson());

                return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error.", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JsonElement jsonElement)
        {
            try
            {
                var document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonElement.GetRawText());
                
                await _repository.InsertAsync(document);
                
                return Ok(new { message = "Documento inserido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao processar documento.", details = ex.Message });
            }
        }

        [HttpPut("account/{accountId}")]
        public async Task<IActionResult> UpdateByAccountId(string accountId, [FromBody] JsonElement jsonElement)
        {
            try
            {
                var updatedDoc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonElement.GetRawText());

                updatedDoc["accountId"] = accountId;

                var success = await _repository.UpdateByAccountIdAsync(accountId, updatedDoc);

                if (!success)
                    return NotFound(new { message = "Account not found." });

                return Ok(new { message = "Account updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error.", details = ex.Message });
            }
        }


        [HttpDelete("account/{accountId}")]
        public async Task<IActionResult> DeleteByAccountId(string accountId)
        {
            try
            {
                var success = await _repository.DeleteByAccountIdAsync(accountId);

                if (!success)
                    return NotFound(new { message = "Account not found." });

                return Ok(new { message = "Account deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error.", details = ex.Message });
            }
        }


    }
}
