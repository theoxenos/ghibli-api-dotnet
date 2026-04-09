namespace GhibliApiNet.Api.Models.Domain;

public class Film
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? OriginalTitle { get; set; }
    public string? OriginalTitleRomanised { get; set; }
    public string? Image { get; set; }
    public string? MovieBanner { get; set; }
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? Producer { get; set; }
    public int? ReleaseDate { get; set; }
    public int? RunningTime { get; set; }
    public int? RtScore { get; set; }
    public List<Person>? People { get; set; }
    public List<Species>? Species { get; set; }
    public List<Location>? Locations { get; set; }
    public List<Vehicle>? Vehicles { get; set; }
}