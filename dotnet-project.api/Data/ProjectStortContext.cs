// using System;
// using dotnet_project.api.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace dotnet_project.api.Data;



// public class ProjectStortContext(DbContextOptions<ProjectStortContext> options)
// : DbContext(options)
// {
//     public DbSet<Project> Projects => Set<Project>();
//     public DbSet<Genre> Genres => Set<Genre>();
// }

using dotnet_project.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_project.api.Data;

public class ProjectStortContext : DbContext
{
    public ProjectStortContext(DbContextOptions<ProjectStortContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Genre> Genres => Set<Genre>();
}

