using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeciesController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Species>>> GetAllSpecies()
    {
        return await dbContext.Species.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Species>> GetSpeciesById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Species ID cannot be null, empty, or whitespace");

        var species = await dbContext.Species.FirstOrDefaultAsync(s => s.Id == id);
        if (species is null) return NotFound($"Species with ID '{id}' not found");

        return species;
    }
}