namespace LibraryProject.API.Models;

public class BookForCreationDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public float Rating { get; set; }
}