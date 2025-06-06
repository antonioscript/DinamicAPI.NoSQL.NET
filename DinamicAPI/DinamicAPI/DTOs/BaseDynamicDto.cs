using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DinamicAPI.DTOs;
public class BaseDynamicDto
{
    [Required]
    public string AccountId { get; set; }

    [Required]
    public string PersonType { get; set; }

    public JsonElement Data { get; set; }
}

