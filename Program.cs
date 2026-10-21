using LoncotesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using LoncotesLibrary.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoncotesLibraryDbContext>(builder.Configuration["LoncotesLibraryDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/materials", (LoncotesLibraryDbContext db, int? materialTypeId, int? genreId) =>
{

    IQueryable<Material> materialsToReturn = db.Materials;


    if (materialTypeId != null)
    {
        materialsToReturn = materialsToReturn.Where(m => m.MaterialTypeId == materialTypeId);
    }

    if (genreId != null)
    {
        materialsToReturn = materialsToReturn.Where(m => m.GenreId == genreId);
    }


    return materialsToReturn
    .Where(m => m.OutOfCirculationSince == null)
    .Select(m => new MaterialDTO
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        GenreId = m.GenreId,
        MaterialType = new MaterialTypeDTO
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        Genre = new GenreDTO
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        }
    });
});

app.MapGet("/api/materialTypes", (LoncotesLibraryDbContext db) =>
{
    return db.MaterialTypes
    .Select(mt => new MaterialTypeDTO
    {
        Id = mt.Id,
        Name = mt.Name,
        CheckoutDays = mt.CheckoutDays
    });
});

app.MapGet("/api/genres", (LoncotesLibraryDbContext db) =>
{
    return db.Genres.Select(g => new GenreDTO
    {
        Id = g.Id,
        Name = g.Name
    });
});


app.Run();

