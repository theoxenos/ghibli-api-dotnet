namespace ConvertJsonToSqlite.Models.Domain;

public class Location
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Climate { get; set; }
    public string? Terrain { get; set; }
    public string? SurfaceWater { get; set; }
    public List<Person>? Residents { get; set; }
    public List<Film>? Films { get; set; }
}
