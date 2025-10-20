namespace dotnet_project.api.Dtos
{
    public record class ProjrctDto(
            int Id,
            string Name,
            string Genre,
            Decimal Price,
            DateOnly ReleaseDate
    );
}