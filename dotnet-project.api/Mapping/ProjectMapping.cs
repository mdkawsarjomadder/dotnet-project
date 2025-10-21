using System;
using dotnet_project.api.Dtos;
using dotnet_project.api.Entities;

namespace dotnet_project.api.Mapping;

public static class ProjectMapping
{
    public static Project ToEntity(this CretaeProjectDto project)
    {

        return new Project
        {
            Name = project.Name,
            GenreId = project.GenreId,
            Price = project.Price,
            ReleaseDate = project.ReleaseDate
        };

    }
     public static Project ToEntity(this UpdateCreateDto project, int id)
    {
       
        return new Project
        {
            Id = id,
            Name = project.Name,
            GenreId = project.GenreId,
            Price = project.Price,
            ReleaseDate = project.ReleaseDate
        };

    }
    public static ProjectSummaryDto ToprojectSummaryDto(this Project project)
    {
        return new(
           project.Id,
           project.Name,
           project.Genre!.Name,
           project.Price,
           project.ReleaseDate
       );
    }
    
    public static ProjectDetilsDto ToprojectDetailsDto(this Project project)
    {
         return new(
            project.Id,
            project.Name,
            project.GenreId,
            project.Price,
            project.ReleaseDate
        );
    }

    internal static object ToEntity(int id)
    {
        throw new NotImplementedException();
    }
}
