using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.API.Entities;

public class Book
{
    [Key] public Guid Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required] [MaxLength(1500)] public string? Description { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(5)]
    public float Rating { get; set; } = 1;

    [ForeignKey("AuthorId")]
    public Author Author { get; set; } = null!;

    public Guid AuthorId { get; set; }
}