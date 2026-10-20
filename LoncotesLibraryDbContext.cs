using Microsoft.EntityFrameworkCore;
using LoncotesLibrary.Models;


public class LoncotesLibraryDbContext : DbContext
{
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<Patron> Patrons { get; set; }

    public LoncotesLibraryDbContext(DbContextOptions<LoncotesLibraryDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>().HasData(new MaterialType[]
        {
            new MaterialType {Id = 1, Name = "Book", CheckoutDays = 21},
            new MaterialType {Id = 2, Name = "CD", CheckoutDays = 7},
            new MaterialType {Id = 3, Name = "DVD", CheckoutDays = 7},
            new MaterialType {Id = 4, Name = "Magazine", CheckoutDays = 3}
        });

        modelBuilder.Entity<Patron>().HasData(new Patron[]
        {
            new Patron {Id = 1, FirstName = "Mustard", LastName = "Mike", Address = "123 Lane", Email ="MustyMike@gmail.com", isActive = true},
            new Patron {Id = 2, FirstName = "Responsible", LastName = "Stanley", Address = "456 Drive", Email ="StanTheMan@yahoo.com", isActive = false},
            new Patron {Id = 3, FirstName = "Clart", LastName = "Kent", Address = "789 Parkway", Email ="NotSuperman@hotmail.com", isActive = false}
        });

        modelBuilder.Entity<Genre>().HasData(
            new Genre[]
            {
               new Genre { Id = 1, Name = "SciFi"},
               new Genre { Id = 2, Name = "Historical Fiction"},
               new Genre { Id = 3, Name = "Literary Fiction"},
               new Genre { Id = 4, Name = "Fantasy"},
               new Genre { Id = 5, Name = "Non-Fiction"},
               new Genre {Id = 6, Name = "Other"}
            });

        modelBuilder.Entity<Material>().HasData(
            new Material[]
            {
                new Material {Id = 1, MaterialName = "I, Claudius", MaterialTypeId = 1, GenreId = 2},
                new Material {Id = 2, MaterialName = "The Forever War", MaterialTypeId = 1, GenreId = 1},
                new Material {Id = 3, MaterialName = "The Fifth Element", MaterialTypeId = 3, GenreId = 1},
                new Material {Id = 4, MaterialName = "Game of Thrones Season 3", MaterialTypeId = 3, GenreId = 4},
                new Material {Id = 5, MaterialName = "The Portraits of John Singer Sargent", MaterialTypeId = 1, GenreId = 5},
                new Material {Id = 6, MaterialName = "In Rainbows", MaterialTypeId = 2, GenreId = 6},
                new Material {Id = 7, MaterialName = "Time", MaterialTypeId = 4, GenreId = 5},
                new Material {Id = 8, MaterialName = "Modern Engineering", MaterialTypeId = 4, GenreId = 5},
                new Material {Id = 9, MaterialName = "Let It Be", MaterialTypeId = 2, GenreId = 6},
                new Material {Id = 10, MaterialName = "Trainspotting", MaterialTypeId = 1, GenreId = 3}
            });

    }
}