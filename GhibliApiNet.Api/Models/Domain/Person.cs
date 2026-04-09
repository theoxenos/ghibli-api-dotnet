namespace GhibliApiNet.Api.Models.Domain;

public class Person
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
    public string? Age { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
    public List<Film>? Films { get; set; }
    public Species? Species { get; set; }
}