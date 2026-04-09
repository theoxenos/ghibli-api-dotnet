using GhibliApiNet.Api.Data;
using GhibliApiNet.Api.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAllPeople()
    {
        return await dbContext.People.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Person>> GetPersonById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Person ID cannot be null, empty, or whitespace");

        var person = await dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
        if (person is null) return NotFound($"Person with ID '{id}' not found");

        return person;
    }
}