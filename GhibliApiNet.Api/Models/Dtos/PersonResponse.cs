namespace GhibliApiNet.Api.Models.Dtos;

public class PersonResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Gender { get; set; }
    public string? Age { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
}