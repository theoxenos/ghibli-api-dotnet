namespace ConvertJsonToSqlite.Models.Domain;

public class Species
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Classification { get; set; }
    public string? EyeColors { get; set; }
    public string? HairColors { get; set; }
    public List<Person>? People { get; set; }
    public List<Film>? Films { get; set; }
}
