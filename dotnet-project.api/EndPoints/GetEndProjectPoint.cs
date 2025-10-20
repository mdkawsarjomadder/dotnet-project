using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.api.Data;
using dotnet_project.api.Dtos;
using dotnet_project.api.Entities;
using dotnet_project.api.Mapping;

namespace dotnet_project.api.EndPoints;

    public static class GetEndProjectPoint
    {
    
        const string GetProjectEndPointName = "ProjectName";

   private static readonly List<ProjectSummaryDto> projects = [
             new(
        1,
        "Street Fighter IT",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7,15)),

           new(
        2,
        "Final  Fantasy xIV",
        "Roleplaying",
        59.99M,
        new DateOnly(2010, 7,15)),

           new(
        3,
        "FIFA 23",
        "Sports",
        69.99M,
        new DateOnly(2022, 9,27))
     ];

   public static RouteGroupBuilder MapProjectEndPoints(this WebApplication app)
   {
      var group = app.MapGroup("projects").WithParameterValidation();
        //GET/projects
        var unused7 = group.MapGet("/", () => projects);

        //GET/group/1
        var unused6 = group.MapGet("/{id}", (int id, ProjectStortContext dbContext) =>
        {
            // ProjrctDto? project = projects.Find(project => project.Id == id);
              Project? project = dbContext.Projects.Find(id);
            // Project? project = dbContext.Genres.Find(id);

            return project is null ? Results.NotFound() : Results.Ok(project. ToprojectDetailsDto());
        }).WithName(GetProjectEndPointName);

        //POST/group/
        var unused5 = group.MapPost("/", (CretaeProjectDto newGame, ProjectStortContext dbContext) =>
        {
            Project project = newGame.ToEntity();
            // project.Genre = dbContext.Genres.Find(newGame.GenreId);

            /*            Project ppject = new()
                        {
                            Name = newGame.Name,
                            Genre = dbContext.Genres.Find(newGame.GenreId),
                            GenreId = newGame.GenreId,
                            Price = newGame.Price,
                            ReleaseDate = newGame.ReleaseDate
                        };
            */

            var unused4 = dbContext.Projects.Add(project);
            var unused3 = dbContext.SaveChanges();
            /*  
                    ProjrctDto projrctDto = new(
                        ppject.Id,
                        ppject.Name,
                        ppject.Genre!.Name,
                        ppject.Price,
                        ppject.ReleaseDate
                    );
            */

            return Results.CreatedAtRoute(
                GetProjectEndPointName,
                new { id = project.Id },
                project.ToprojectDetailsDto());
        });
        //PUT/group/
        var unused2 = group.MapPut("/{id}", (int id, UpdateCreateDto newUpdate) =>
        {
            var index = projects.FindIndex(project => project.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            projects[index] = new ProjectSummaryDto(
                id,
                newUpdate.Name,
                newUpdate.GenreId,
                newUpdate.Price,
                newUpdate.ReleaseDate
                );
            return Results.NoContent();
        });
        //Delete/group
        var unused1 = group.MapDelete("/{id}", (int id) =>
        {
            var unused = projects.RemoveAll(project => project.Id == id);
            return Results.NoContent();

        });
        return group;

    }
        
    }
        
    
