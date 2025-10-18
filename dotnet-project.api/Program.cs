using System.Diagnostics.Metrics;
using dotnet_project.api.Dtos;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        const string GetProjectEndPointName = "ProjectName";

        List<ProjrctDto> projects = [
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
        //GET/projects
        app.MapGet("projects", () => projects);

        //GET/projects/1
        app.MapGet("projects/{id}", (int id) =>
        {
            ProjrctDto? project = projects.Find(project => project.Id == id);
            return project is null ? Results.NotFound() : Results.Ok(project);
        }).WithName(GetProjectEndPointName);

        //POST/project/
        app.MapPost("projects", (CretaeProjectDto newGame) =>
        {
            ProjrctDto projrct = new(
                projects.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);
            projects.Add(projrct);

            return Results.CreatedAtRoute(GetProjectEndPointName, new { id = projrct.Id }, projrct);

        });
        //PUT/project/
        app.MapPut("projects/{id}", (int id, UpdateCreateDto newUpdate) =>
        {
            var index = projects.FindIndex(project => project.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            projects[index] = new ProjrctDto(
                id,
                newUpdate.Name,
                newUpdate.Genre,
                newUpdate.Price,
                newUpdate.ReleaseDate
                );
            return Results.NoContent();
        });
        //Delete/projetcs
        app.MapDelete("projects/{id}", (int id) =>
        {
            projects.RemoveAll(project => project.Id == id);
            return Results.NoContent();

        });

        app.Run();
    }
}