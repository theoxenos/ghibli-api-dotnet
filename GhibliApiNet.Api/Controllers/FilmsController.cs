using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
using GhibliApiNet.Api.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Film>>> GetAllFilms([FromQuery] string? title)
    {
        var films = await dbContext.Films
            .Where(f => string.IsNullOrEmpty(title) || f.Title.ToLower().Contains(title.ToLower()))
            .OrderBy(f => f.ReleaseDate)
            .ToListAsync();
        return films;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<FilmResponse>> GetFilmById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Film ID cannot be null, empty, or whitespace");

        var film = await dbContext.Films
            .Include(film => film.Locations)
            .Include(f => f.People)
            .Include(f => f.Species)
            .Include(f => f.Vehicles)
            .FirstOrDefaultAsync(f => f.Id == id);
        if (film is null) return NotFound($"Film with ID '{id}' not found");

        return new FilmResponse
        {
            Id = film.Id,
            Title = film.Title,
            OriginalTitle = film.OriginalTitle,
            OriginalTitleRomanised = film.OriginalTitleRomanised,
            Image = film.Image,
            MovieBanner = film.MovieBanner,
            Description = film.Description,
            ReleaseDate = film.ReleaseDate,
            RtScore = film.RtScore,
            Producer = film.Producer,
            RunningTime = film.RunningTime,
            Director = film.Director,
            Species = film.Species?.Select(s => new SpeciesResponse
            {
                Name = s.Name,
                Id = s.Id,
                Classification = s.Classification,
                EyeColors = s.EyeColors,
                HairColors = s.HairColors
            }).ToList() ?? [],
            Locations = film.Locations?.Select(l => new LocationResponse
            {
                Id = l.Id,
                Name = l.Name,
                Climate = l.Climate,
                Terrain = l.Terrain,
                SurfaceWater = l.SurfaceWater
            }).ToList() ?? [],
            People = film.People?.Select(p => new PersonResponse
            {
                Id = p.Id,
                Name = p.Name,
                Gender = p.Gender,
                Age = p.Age,
                EyeColor = p.EyeColor,
                HairColor = p.HairColor
            }).ToList() ?? [],
            Vehicles = film.Vehicles?.Select(v => new VehicleResponse
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                VehicleClass = v.VehicleClass,
                Length = v.Length
            }).ToList() ?? []
        };
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Film>> UpdateFilm(string id, FilmUpsertDto? film)
    {
        if (film is null) return BadRequest("Film cannot be null");

        if (string.IsNullOrWhiteSpace(film.Id)) return BadRequest("Film ID cannot be null, empty, or whitespace");

        var existingFilm = await dbContext.Films.FindAsync(film.Id);
        if (existingFilm is null) return NotFound($"Film with ID '{film.Id}' not found");

        dbContext.Entry(existingFilm).CurrentValues.SetValues(film);
        await dbContext.SaveChangesAsync();

        return Ok(film);
    }
}