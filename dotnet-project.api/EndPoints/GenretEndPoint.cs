using System;
using dotnet_project.api.Data;
using dotnet_project.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project.api.EndPoints;

public static class GenretEndPoint
{
  public static RouteGroupBuilder MapGenresEndPoint(this WebApplication app)
  {
      var group = app.MapGroup("genres");
      
      group.MapGet("/", async (ProjectStortContext dbContext) =>
          await dbContext.Genres
              .Select(genre => genre.ToDto())
              .AsNoTracking()
              .ToListAsync()
      );

      return group;
  }
}
