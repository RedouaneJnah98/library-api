using System.ComponentModel.DataAnnotations;

namespace LibraryProject.API.Entities;

public class Author
{
    [Key] public Guid Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] public DateTimeOffset DateOfBirth { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(5)]
    public float Rating { get; set; } = 1;

    [Required] public string Nationality { get; set; }

    [Required]
    public ICollection<Book> Books { get; set; }
        = new List<Book>();
}