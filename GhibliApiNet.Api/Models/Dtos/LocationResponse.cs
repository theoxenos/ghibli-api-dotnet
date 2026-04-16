namespace GhibliApiNet.Api.Models.Dtos;

public class LocationResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Climate { get; set; }
    public string? Terrain { get; set; }
    public int? SurfaceWater { get; set; }
}