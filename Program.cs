using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using TasksProject;
using TasksProject.Context;

var builder = WebApplication.CreateBuilder(args);
AppSettings.BindSettings(builder.Configuration);


// Services container
var services = builder.Services;
services.AddControllers().AddNewtonsoftJson();
services.AddHealthChecks();
services.AddEndpointsApiExplorer();

services.AddSwaggerGen(options =>
{
    var version = AppSettings.Settings.Version;

    options.SwaggerDoc(version, new OpenApiInfo
    {
        Title = "Minimal task Api",
        Version = version,
        Description = "First Api in Dotnet using EF and learning about deep configuration in a WebApi project"
    });
});


// Database configuration
var connectionString = AppSettings.Settings.ConnectionString;
services.AddDbContext<AssignmentContext>(option => option.UseMySQL(connectionString));


// Dependency injection
Bootstrapper.BootStrap();


// BUILD
var app = builder.Build();


// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("tasks");
app.UseRouting();

// Controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("api/HealthCheck");

    app.MapGet("/dbconnection", ([FromServices] AssignmentContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok(dbContext.Database.IsRelational());
    });
});


// RUN
app.Run();
