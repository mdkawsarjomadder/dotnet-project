namespace dotnet_project.api.Dtos;

public record class UpdateCreateDto
(
    string Name,
        string Genre,
        Decimal Price,
        DateOnly ReleaseDate
);
