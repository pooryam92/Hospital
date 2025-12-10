using FastEndpoints;
using FastEndpoints.Swagger;
using Hospital.Application;
using Hospital.Infrastructure;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.EnableGetRequestsWithBody = false;
});
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

app.MapOpenApi();
app.UseFastEndpoints();
app.UseSwaggerGen();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HospitalContext>();
    db.Database.EnsureCreated();
    var seeder = scope.ServiceProvider.GetRequiredService<Seed>();
    await seeder.SeedDataAsync();
}

app.Run();

public partial class Program { }