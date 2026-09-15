# GhibliApiNet

A .NET 10 REST API providing structured access to Studio Ghibli films, characters, species, locations, and vehicles. The project serves resource endpoints backed by an embedded SQLite database using Entity Framework Core.

### Controllers and Endpoints

All API routes use the `api/[controller]` route pattern and return JSON responses.

- [`FilmsController`](./GhibliApiNet.Api/Controllers/FilmsController.cs): `GET /api/films` returns all films and supports optional `title`, `director`, and `producer` query filters. `GET /api/films/{id}` returns a film with its related people, species, locations, and vehicles. `PUT /api/films/{id}` updates an existing film.
- [`PeopleController`](./GhibliApiNet.Api/Controllers/PeopleController.cs): `GET /api/people` returns all people, while `GET /api/people/{id}` returns one person.
- [`LocationsController`](./GhibliApiNet.Api/Controllers/LocationsController.cs): `GET /api/locations` returns all locations, while `GET /api/locations/{id}` returns one location.
- [`SpeciesController`](./GhibliApiNet.Api/Controllers/SpeciesController.cs): `GET /api/species` returns all species, while `GET /api/species/{id}` returns one species.
- [`VehiclesController`](./GhibliApiNet.Api/Controllers/VehiclesController.cs): `GET /api/vehicles` returns all vehicles, while `GET /api/vehicles/{id}` returns one vehicle.

The collection endpoints return complete resource lists. The identifier endpoints return a single resource or a `404 Not Found` response when the requested identifier does not exist. Invalid request data returns `400 Bad Request`.

### External Libraries

- [Scalar](https://github.com/scalar/scalar) ([`Scalar.AspNetCore`](https://www.nuget.org/packages/Scalar.AspNetCore)): Interactive OpenAPI documentation. Start the API in the Development environment, then open [Scalar at `https://localhost:7126/scalar/v1`](https://localhost:7126/scalar/v1) or [Scalar at `http://localhost:5099/scalar/v1`](http://localhost:5099/scalar/v1) in a browser.
- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi): Built-in ASP.NET Core OpenAPI metadata generation.
- [Entity Framework Core SQLite](https://learn.microsoft.com/ef/core/) ([`Microsoft.EntityFrameworkCore.Sqlite`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite)): Embedded SQLite relational database provider.
- [.NET HTTP Client Files](https://www.jetbrains.com/help/rider/HTTP_Client_in_Editor_tool_window.html): Integrated `.http` specification files ([`films.http`](./GhibliApiNet.Api/films.http), [`people.http`](./GhibliApiNet.Api/people.http), [`locations.http`](./GhibliApiNet.Api/locations.http), [`species.http`](./GhibliApiNet.Api/species.http), [`vehicles.http`](./GhibliApiNet.Api/vehicles.http)) allowing in-editor request execution without external API clients.

### Project Structure

```text
.
├── .gitignore
├── GhibliApiNet.sln
├── GhibliApiNet.sln.DotSettings.user
├── README.md
└── GhibliApiNet.Api/
    ├── Controllers/
    ├── Data/
    ├── Models/
    │   ├── Domain/
    │   └── Dtos/
    └── Properties/
```

- [`GhibliApiNet.Api`](./GhibliApiNet.Api): Main ASP.NET Core Web API project root.
- [`GhibliApiNet.Api/Controllers`](./GhibliApiNet.Api/Controllers): API controllers defining REST endpoints for films, locations, people, species, and vehicles.
- [`GhibliApiNet.Api/Data`](./GhibliApiNet.Api/Data): Database context (`ApplicationDbContext`), the SQLite database file, and seed dataset.
- [`GhibliApiNet.Api/Models`](./GhibliApiNet.Api/Models): Data model definitions split between domain entities ([`Domain`](./GhibliApiNet.Api/Models/Domain)) and data transfer objects ([`Dtos`](./GhibliApiNet.Api/Models/Dtos)).
- [`GhibliApiNet.Api/Properties`](./GhibliApiNet.Api/Properties): Project launch settings and environment profile definitions.

### Credits

- Inspired by and seeded with data from the original [ghibliapi](https://github.com/janaipakos/ghibliapi) project by [janaipakos](https://github.com/janaipakos).
