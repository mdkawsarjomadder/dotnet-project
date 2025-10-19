using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.api.Dtos;

namespace dotnet_project.api.EndPoints;

    public static class GetEndProjectPoint
    {
    
        const string GetProjectEndPointName = "ProjectName";

   private static readonly List<ProjrctDto> projects = [
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
        group.MapGet("/",() => projects);

        //GET/group/1
        group.MapGet("/{id}", (int id) =>
        {
            ProjrctDto? project = projects.Find(project => project.Id == id);
            return project is null ? Results.NotFound() : Results.Ok(project);
        }).WithName(GetProjectEndPointName);

        //POST/group/
        group.MapPost("/", (CretaeProjectDto newGame) =>
        {
            ProjrctDto projrct = new(
                projects.Count + 1,
                newGame.Name,
                newGame.GenreId,
                newGame.Price,
                newGame.ReleaseDate);
            projects.Add(projrct);

            return Results.CreatedAtRoute(GetProjectEndPointName, new { id = projrct.Id }, projrct);
        });
        //PUT/group/
        group.MapPut("/{id}", (int id, UpdateCreateDto newUpdate) =>
        {
            var index = projects.FindIndex(project => project.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            projects[index] = new ProjrctDto(
                id,
                newUpdate.Name,
                newUpdate.GenreId,
                newUpdate.Price,
                newUpdate.ReleaseDate
                );
            return Results.NoContent();
        });
      //Delete/group
      app.MapDelete("/{id}", (int id) =>
      {
         projects.RemoveAll(project => project.Id == id);
         return Results.NoContent();

      });
      return group;

    }
        
    }
        
    
