using System;

namespace dotnet_project.api.Dtos;

public record class ProjectDetilsDto
(
    int Id,
    string Name,
    int  GenreId,
    Decimal Price,
    DateOnly ReleaseDate
);
