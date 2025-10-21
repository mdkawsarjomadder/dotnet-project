using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project.api.Data;

public static class DataExterstion
{
   public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var sCope = app.Services.CreateScope();
        var dbContext = sCope.ServiceProvider.GetRequiredService<ProjectStortContext>();
        await dbContext.Database.MigrateAsync();
    }
}
