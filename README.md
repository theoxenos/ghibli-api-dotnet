# GhibliApiNet

A .NET 10 REST API providing structured access to Studio Ghibli films, characters, species, locations, and vehicles. The project serves resource endpoints backed by an embedded SQLite database using Entity Framework Core.

### Interesting Techniques

- **Dynamic Query Filtering**: The [`FilmsController`](./GhibliApiNet.Api/Controllers/FilmsController.cs) applies dynamic LINQ filtering on title, director, and producer based on optional [URL query parameters](https://developer.mozilla.org/en-US/docs/Web/API/URLSearchParams).
- **Relational Eager Loading and DTO Projections**: Related entities (people, species, locations, vehicles) are eagerly loaded via EF Core `.Include()` and projected into flat Data Transfer Objects ([`Dtos`](./GhibliApiNet.Api/Models/Dtos)) to prevent circular references and maintain clean API contracts.
- **Change Tracker Entity Updates**: The [`PUT`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/PUT) endpoint in [`FilmsController`](./GhibliApiNet.Api/Controllers/FilmsController.cs) uses `DbContext.Entry().CurrentValues.SetValues()` to update modified fields directly from the DTO without manual property mapping.
- **Semantic HTTP Status Handling**: Endpoints validate incoming identifiers and return appropriate [HTTP status codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status) including [`200 OK`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/200), [`400 Bad Request`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400), and [`404 Not Found`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/404).
- **Primary Constructors**: Controllers and database contexts utilize modern C# primary constructor syntax to inject dependencies without explicit private field declarations.
- **Direct JSON Content Negotiation**: Endpoints process and return structured payloads using standard [`application/json`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Type) representations.

### Non-Obvious Technologies and External Libraries

- [Scalar](https://github.com/scalar/scalar) ([`Scalar.AspNetCore`](https://www.nuget.org/packages/Scalar.AspNetCore)): Modern interactive OpenAPI UI integrated via `app.MapScalarApiReference()` to provide a fast alternative to Swagger UI.
- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi): Built-in ASP.NET Core OpenAPI metadata generation.
- [Entity Framework Core SQLite](https://learn.microsoft.com/ef/core/) ([`Microsoft.EntityFrameworkCore.Sqlite`](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite)): Embedded SQLite relational database provider.
- [.NET HTTP Client Files](https://www.jetbrains.com/help/rider/HTTP_Client_in_Editor_tool_window.html): Integrated `.http` specification files ([`films.http`](./GhibliApiNet.Api/films.http), [`people.http`](./GhibliApiNet.Api/people.http), [`locations.http`](./GhibliApiNet.Api/locations.http), [`species.http`](./GhibliApiNet.Api/species.http), [`vehicles.http`](./GhibliApiNet.Api/vehicles.http)) allowing in-editor request execution without external API clients.
- **Fonts**: As a headless backend API, no custom web fonts or typography packages are bundled.

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
