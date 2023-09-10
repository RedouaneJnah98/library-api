namespace LibraryProject.API.Models;

public class AuthorForUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTimeOffset DateOfBirth { get; set; }
    public float Rating { get; set; }
    public string Nationality { get; set; } = string.Empty;
}