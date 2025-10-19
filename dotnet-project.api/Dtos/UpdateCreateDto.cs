using System.ComponentModel.DataAnnotations;

namespace dotnet_project.api.Dtos;

public record class UpdateCreateDto
(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(30)]string Genre,
        [Range(1,100)]Decimal Price,
        DateOnly ReleaseDate
);
