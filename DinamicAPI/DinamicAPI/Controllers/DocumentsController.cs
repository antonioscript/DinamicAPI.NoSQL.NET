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


        [HttpPost("{collection}")]
        public async Task<IActionResult> Post(string collection, [FromBody] JsonElement jsonElement)
        {
            try
            {
                var document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonElement.GetRawText());
                
                await _repository.InsertAsync(collection, document);

                return Ok(new { message = "Documento inserido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao processar documento.", details = ex.Message });
            }
        }


        [HttpGet("{collection}")]
        public async Task<IActionResult> Get(string collection)
        {
            try
            {
                var docs = await _repository.GetAllAsync(collection);

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

    }
}
