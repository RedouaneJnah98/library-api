namespace LibraryProject.API.Models;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public float Rating { get; set; }
}