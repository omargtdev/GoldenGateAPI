using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenGateAPI.Models;

public class Property
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Direction { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }
    
    public string? Picture { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

    public DateTime? LastUpdateDate { get; set; }

    public Guid? UserId { get; set; }

}
