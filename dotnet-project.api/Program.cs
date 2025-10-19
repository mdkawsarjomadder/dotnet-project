using System.Diagnostics.Metrics;
using dotnet_project.api.Dtos;
using dotnet_project.api.EndPoints;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.MapProjectEndPoints();
        app.Run();
    }
}