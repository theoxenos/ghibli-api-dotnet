using System.Text.Json;
using ConvertJsonToSqlite.Data;
using ConvertJsonToSqlite.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Film = ConvertJsonToSqlite.Models.Domain.Film;
using Location = ConvertJsonToSqlite.Models.Domain.Location;

// Specify the path to your JSON file
var jsonFilePath = "data.json";

if (!File.Exists(jsonFilePath))
{
    Console.WriteLine($"File not found: {jsonFilePath}");
    return;
}

try
{
    var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
    var data = JsonSerializer.Deserialize<GhibliData>(jsonContent);

    File.Delete("ghibli-films.db");
    
    using var context = new ApplicationContext();
    context.Database.Migrate();

    var dbFilms = new List<Film>();
    dbFilms.AddRange(data.Films.Select(film => new Film
    {
        Id = film.Id,
        Title = film.Title,
        Description = film.Description,
        ReleaseDate = film.ReleaseDate,
        RtScore = film.RtScore,
        Producer = film.Producer,
        RunningTime = film.RunningTime,
        Director = film.Director,
        Image = film.Image,
        MovieBanner = film.MovieBanner,
        OriginalTitle = film.OriginalTitle,
        OriginalTitleRomanised = film.OriginalTitleRomanised,
    }));

    var dbLocations = new List<Location>();
    dbLocations.AddRange(data.Locations.Select(location => new Location
    {
        Id = location.Id,
        Name = location.Name,
        Climate = location.Climate,
        Terrain = location.Terrain,
        SurfaceWater = location.SurfaceWater,
    }));

    var dbPeople = new List<ConvertJsonToSqlite.Models.Domain.Person>();
    dbPeople.AddRange(data.People.Select(person => new ConvertJsonToSqlite.Models.Domain.Person
    {
        Id = person.Id,
        Name = person.Name,
        Gender = person.Gender,
        Age = person.Age,
        EyeColor = person.EyeColor,
        HairColor = person.HairColor,
    }));

    var dbSpecies = new List<ConvertJsonToSqlite.Models.Domain.Species>();
    dbSpecies.AddRange(data.Species.Select(species => new ConvertJsonToSqlite.Models.Domain.Species
    {
        Id = species.Id,
        Name = species.Name,
        Classification = species.Classification,
        EyeColors = species.EyeColors,
        HairColors = species.HairColors,
    }));

    var dbVehicles = new List<ConvertJsonToSqlite.Models.Domain.Vehicle>();
    dbVehicles.AddRange(data.Vehicles.Select(vehicle => new ConvertJsonToSqlite.Models.Domain.Vehicle
    {
        Id = vehicle.Id,
        Name = vehicle.Name,
        Description = vehicle.Description,
        VehicleClass = vehicle.VehicleClass,
        Length = vehicle.Length,
    }));

    context.Films.AddRange(dbFilms.Select(film =>
    {
        var filmFromJsonData = data.Films.First(f => f.Id == film.Id);
        film.Locations = dbLocations.Where(l => filmFromJsonData.Locations.Contains(l.Id)).ToList();
        film.Species = dbSpecies.Where(s => filmFromJsonData.Species.Contains(s.Id)).ToList();
        film.People = dbPeople.Where(p => filmFromJsonData.People.Contains(p.Id)).ToList();
        film.Vehicles = dbVehicles.Where(v => filmFromJsonData.Vehicles.Contains(v.Id)).ToList();
        return film;
    }));

    context.Locations.AddRange(dbLocations.Select(location =>
    {
        var locationFromJsonData = data.Locations.First(l => l.Id == location.Id);
        location.Films = dbFilms.Where(f => locationFromJsonData.Films.Contains(f.Id)).ToList();
        location.Residents = dbPeople.Where(p => locationFromJsonData.Residents.Contains(p.Id)).ToList();       
        return location;
    }));

    context.People.AddRange(dbPeople.Select(person =>
    {
        var personFromJsonData = data.People.First(p => p.Id == person.Id);
        // person.Films = dbFilms.Where(f => personFromJsonData.Films.Contains(f.Id)).ToList();
        person.Species = dbSpecies.FirstOrDefault(s => s.Id == personFromJsonData.Species);
        return person;
    }));

    // context.Species.AddRange(dbSpecies.Select(species =>
    // {
    //     var speciesFromJsonData = data.Species.First(s => s.Id == species.Id);
    //     species.Films = dbFilms.Where(f => speciesFromJsonData.Films.Contains(f.Id)).ToList();
    //     species.People = dbPeople.Where(p => speciesFromJsonData.People.Contains(p.Id)).ToList();
    //     return species;
    // }));

    context.Vehicles.AddRange(dbVehicles.Select(vehicle =>
    {
        var vehicleFromJsonData = data.Vehicles.First(v => v.Id == vehicle.Id);
        vehicle.Pilot = dbPeople.FirstOrDefault(p => p.Id == vehicleFromJsonData.Pilot);
        return vehicle;
    }));

    await context.SaveChangesAsync();
    Console.WriteLine("Data migration completed successfully.");
}
catch (JsonException ex)
{
    Console.WriteLine($"Error parsing JSON: {ex.Message}");
}
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
// }