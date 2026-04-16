namespace GhibliApiNet.Api.Models.Dtos;

public class SpeciesResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Classification { get; set; }
    public string? EyeColors { get; set; }
    public string? HairColors { get; set; }
}