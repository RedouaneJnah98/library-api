namespace LibraryProject.API.Models;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public float Rating { get; set; }
    public string Nationality { get; set; } = string.Empty;
}