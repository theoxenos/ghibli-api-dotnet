namespace GhibliApiNet.Api.Models.Dtos;

public class VehicleResponse
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? VehicleClass { get; set; }
    public int? Length { get; set; }
}