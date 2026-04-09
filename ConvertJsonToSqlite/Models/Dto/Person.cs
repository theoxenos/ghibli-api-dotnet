using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Dto;

public class Person
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("age")]
    public string? Age { get; set; }

    [JsonPropertyName("eye_color")]
    public string? EyeColor { get; set; }

    [JsonPropertyName("hair_color")]
    public string? HairColor { get; set; }

    [JsonPropertyName("films")]
    public List<string>? Films { get; set; }

    [JsonPropertyName("species")]
    public string? Species { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
