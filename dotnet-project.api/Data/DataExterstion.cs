using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project.api.Data;

public static class DataExterstion
{
   public static void MigrateDb(this WebApplication app)
    {
        using var sCope = app.Services.CreateScope();
        var dbContext = sCope.ServiceProvider.GetRequiredService<ProjectStortContext>();
        dbContext.Database.Migrate();
    }
}
