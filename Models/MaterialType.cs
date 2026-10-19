using System.ComponentModel.DataAnnotations;
namespace LocotesLibrary.Models;

public class MaterialTypeId
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int CheckoutDays { get; set; }
}