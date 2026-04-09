using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Dto;

public class Location
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("climate")]
    public string? Climate { get; set; }

    [JsonPropertyName("terrain")]
    public string? Terrain { get; set; }

    [JsonPropertyName("surface_water")]
    public string? SurfaceWater { get; set; }

    [JsonPropertyName("residents")]
    public List<string>? Residents { get; set; }

    [JsonPropertyName("films")]
    public List<string>? Films { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
