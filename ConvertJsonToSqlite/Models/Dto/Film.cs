using System.Text.Json.Serialization;

namespace ConvertJsonToSqlite.Models.Dto;

public class Film
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }

    [JsonPropertyName("original_title_romanised")]
    public string? OriginalTitleRomanised { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("movie_banner")]
    public string? MovieBanner { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("director")]
    public string? Director { get; set; }

    [JsonPropertyName("producer")]
    public string? Producer { get; set; }

    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }

    [JsonPropertyName("running_time")]
    public string? RunningTime { get; set; }

    [JsonPropertyName("rt_score")]
    public string? RtScore { get; set; }

    [JsonPropertyName("people")]
    public List<string>? People { get; set; }

    [JsonPropertyName("species")]
    public List<string>? Species { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("vehicles")]
    public List<string>? Vehicles { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}