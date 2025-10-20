
using dotnet_project.api.Data;
using dotnet_project.api.EndPoints;


var builder = WebApplication.CreateBuilder(args);
//DataBase..!
var ConnString = builder.Configuration.GetConnectionString("dotnet_project");
builder.Services.AddSqlite<ProjectStortContext>(ConnString);
//Scope....!


//DataBase End.!
var app = builder.Build();

app.MapProjectEndPoints();
app.MigrateDb();

app.Run();
    

