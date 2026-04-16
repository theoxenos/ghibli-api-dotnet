namespace GhibliApiNet.Api.Models.Dtos;

public class FilmUpsertDto
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
}