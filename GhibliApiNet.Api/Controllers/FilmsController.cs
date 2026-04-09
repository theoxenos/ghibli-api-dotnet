using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
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
        var films = await dbContext.Films.Where(f => string.IsNullOrEmpty(title) || f.Title.Contains(title))
            .ToListAsync();
        return films;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Film>> GetFilmById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Film ID cannot be null, empty, or whitespace");

        var film = await dbContext.Films.FirstOrDefaultAsync(f => f.Id == id);
        if (film is null) return NotFound($"Film with ID '{id}' not found");

        return film;
    }
}