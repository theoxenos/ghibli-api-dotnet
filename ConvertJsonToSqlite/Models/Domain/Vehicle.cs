using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Domain;

public class Vehicle
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("vehicle_class")]
    public string? VehicleClass { get; set; }

    [JsonPropertyName("length")]
    public string? Length { get; set; }

    [JsonPropertyName("pilot")]
    public string? Pilot { get; set; }

    [JsonPropertyName("films")]
    public List<string>? Films { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
