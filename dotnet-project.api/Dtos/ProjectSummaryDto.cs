using System;

namespace dotnet_project.api.Dtos;

public record class ProjectSummaryDto
(
        int Id,
        string Name,
        string Genre,
        Decimal Price,
        DateOnly ReleaseDate
);
