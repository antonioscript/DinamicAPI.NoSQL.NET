using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DinamicAPI.Repositories;

namespace DinamicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DynamoController : ControllerBase
    {
        private readonly IDynamoRepository _repository;

        public DynamoController(IDynamoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JsonElement document)
        {
            await _repository.InsertAsync(document);

            return Ok(new { message = "Saved to DynamoDB." });
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(string accountId)
        {
            var doc = await _repository.GetByAccountIdAsync(accountId);

            if (doc == null)
                return NotFound();

            return Ok(doc);
        }
    }
}
