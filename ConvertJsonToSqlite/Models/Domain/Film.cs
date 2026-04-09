namespace ConvertJsonToSqlite.Models.Domain;

public class Film
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? OriginalTitle { get; set; }
    public string? OriginalTitleRomanised { get; set; }
    public string? Image { get; set; }
    public string? MovieBanner { get; set; }
    public string? Description { get; set; }
    public string? Director { get; set; }
    public string? Producer { get; set; }
    public string? ReleaseDate { get; set; }
    public string? RunningTime { get; set; }
    public string? RtScore { get; set; }
    public List<Person>? People { get; set; }
    public List<Species>? Species { get; set; }
    public List<Location>? Locations { get; set; }
    public List<Vehicle>? Vehicles { get; set; }
}