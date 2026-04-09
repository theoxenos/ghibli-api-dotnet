using GhibliApiNet.Api.MongoDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace GhibliApiNet.Api.MongoDb.Controllers;

[ApiController, Route("api/films")]
public class FilmsController(MongoDBService mongoDbService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFilms()
    {
        var films = await mongoDbService.GetAllFilmsAsync();
        return Ok(films);
    }
}