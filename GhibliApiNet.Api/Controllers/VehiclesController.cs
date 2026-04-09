using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> GetAllVehicles()
    {
        return await dbContext.Vehicles.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicleById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Vehicle ID cannot be null, empty, or whitespace");

        var vehicle = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        if (vehicle is null) return NotFound($"Vehicle with ID '{id}' not found");

        return vehicle;
    }
}