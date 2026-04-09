namespace ConvertJsonToSqlite.Models.Domain;

public class Vehicle
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? VehicleClass { get; set; }
    public string? Length { get; set; }
    public Person? Pilot { get; set; }
    public List<Film>? Films { get; set; }
}
