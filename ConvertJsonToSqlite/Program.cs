using System.Text.Json;
using ConvertJsonToSqlite.Models;
using ConvertJsonToSqlite.Models.Dto;

// Specify the path to your JSON file
var jsonFilePath = "data.json";

if (!File.Exists(jsonFilePath))
{
    Console.WriteLine($"File not found: {jsonFilePath}");
    return;
}

try
{
    // Read the JSON file content
    string jsonContent = await File.ReadAllTextAsync(jsonFilePath);

    // Deserialize JSON to objects
    var data = JsonSerializer.Deserialize<GhibliData>(jsonContent);
}
catch (JsonException ex)
{
    Console.WriteLine($"Error parsing JSON: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}