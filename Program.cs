using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksProject;
using TasksProject.Context;

var builder = WebApplication.CreateBuilder(args);
new Startup(builder.Configuration).ConfigureServices(builder.Services);

builder.Services.AddDbContext<AssignmentContext>(option => option.UseMySQL(AppSettings.Settings.ConnectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("tasks");
app.MapControllers();

app.MapGet("/", () => "HolaMundo");


app.MapGet("/dbconnection", ([FromServices] AssignmentContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok(dbContext.Database.IsRelational());
});


app.Run();
