using System.ComponentModel.DataAnnotations;

namespace dotnet_project.api.Dtos;

        public record class CretaeProjectDto(
        [Required][StringLength(50)] string Name,
        int GenreId,
        [Range(1,100)]Decimal Price,
        DateOnly ReleaseDate
    );