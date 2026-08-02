using FireOps.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using FireOps.Domain.Interfaces;
using FireOps.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FireOpsDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("FireOpsDatabase")));

builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
