using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Dto;

public class Species
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("classification")]
    public string? Classification { get; set; }

    [JsonPropertyName("eye_colors")]
    public string? EyeColors { get; set; }

    [JsonPropertyName("hair_colors")]
    public string? HairColors { get; set; }

    [JsonPropertyName("people")]
    public List<string>? People { get; set; }

    [JsonPropertyName("films")]
    public List<string>? Films { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
