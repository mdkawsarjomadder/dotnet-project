
using dotnet_project.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project.api.Data;

public class ProjectStortContext(DbContextOptions<ProjectStortContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var unused = modelBuilder.Entity<Genre>().HasData(
         new { Id = 1, Name = "Fighting" },
         new { Id = 2, Name = "Roleplaying" },
         new { Id = 3, Name = "Sports" },
         new { Id = 4, Name = "Racing" },
         new { Id = 5, Name = "Kids and family" }
        );
    }
}

