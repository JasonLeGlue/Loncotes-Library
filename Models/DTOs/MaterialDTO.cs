using LocotesLibrary.Models;

namespace LoncotesLibrary.Models.DTOs;

public class MaterialDTO
{
    public int Id { get; set; }
    public string MaterialName { get; set; }
    public int MaterialTypeId { get; set; }
    public int GenreId { get; set; }
    public DateTime OutOfCirculationSince { get; set; }
    public MaterialType MaterialType { get; set; }
    public Genre Genre { get; set; }
}