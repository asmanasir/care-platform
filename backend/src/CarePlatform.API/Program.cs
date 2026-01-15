using Capacity.Application.Commands.CreateBed;
using Capacity.Application.Commands.OccupyBed;
using Capacity.Application.Commands.ReleaseBed;
using Capacity.Application.Interfaces;
using Capacity.Infrastructure.Persistence;
using Capacity.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<CapacityDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("CapacityDb")
    ));

// Repositories
builder.Services.AddScoped<IBedRepository, BedRepository>();

// Application handlers
builder.Services.AddScoped<OccupyBedCommandHandler>();
builder.Services.AddScoped<CreateBedCommandHandler>();
builder.Services.AddScoped<ReleaseBedCommandHandler>();

var app = builder.Build();

// --------------------
// Middleware
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
