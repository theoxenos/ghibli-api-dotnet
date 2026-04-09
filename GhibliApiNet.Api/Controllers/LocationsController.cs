using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetAllLocations()
    {
        return await dbContext.Locations.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Location>> GetLocationById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Film ID cannot be null, empty, or whitespace");

        var location = await dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
        if (location is null) return NotFound($"Location with ID '{id}' not found");

        return location;
    }
}