using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Dto;

public class GhibliData
{
    [JsonPropertyName("films")]
    public List<Film>? Films { get; set; }

    [JsonPropertyName("people")]
    public List<Person>? People { get; set; }

    [JsonPropertyName("locations")]
    public List<Location>? Locations { get; set; }

    [JsonPropertyName("species")]
    public List<Species>? Species { get; set; }

    [JsonPropertyName("vehicles")]
    public List<Vehicle>? Vehicles { get; set; }
}
