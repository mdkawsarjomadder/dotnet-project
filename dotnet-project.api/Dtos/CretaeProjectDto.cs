namespace dotnet_project.api.Dtos;

    public record class CretaeProjectDto(
        string Name,
        string Genre,
        Decimal Price,
        DateOnly ReleaseDate
    );