namespace LibraryProject.API.Models;

public class AuthorForCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTimeOffset DateOfBirth { get; set; }
    public float Rating { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public ICollection<BookForCreationDto> Books { get; set; } = new List<BookForCreationDto>();
}