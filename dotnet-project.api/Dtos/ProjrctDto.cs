namespace dotnet_project.api.Dtos
{
    public record class ProjrctDto(
            int Id,
            string Name,
            string GenreId,
            Decimal Price,
            DateOnly ReleaseDate
    );
}