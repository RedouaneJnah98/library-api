using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers;

[ApiController]
[Route("api/authors/{authorId}/books")]
public class BooksController : ControllerBase
{
}