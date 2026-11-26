using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "User Id=postgres;Password=12345;Host=localhost;Port=5432;Database=postgres;";

builder.Services.AddControllers();

builder.Services.AddDbContext<AssetManagmentContext>(cnt => cnt.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMachineToolRepository, MachineToolRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<IMachineToolService, MachineToolService>();
builder.Services.AddScoped<ISensorService, SensorService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
