using AutoMapper;
using LibraryProject.API.Entities;
using LibraryProject.API.Models;
using LibraryProject.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public AuthorsController(IMapper mapper, ILibraryRepository libraryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _libraryRepository = libraryRepository ?? throw new ArgumentNullException(nameof(libraryRepository));
    }

    [HttpGet(Name = "GetAuthors")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        var authorResult = await _libraryRepository
            .GetAuthorsAsync();

        return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorResult));
    }

    [HttpPost]
    public async Task<ActionResult<AuthorForCreationDto>> CreateAuthor(AuthorForCreationDto author)
    {
        var authorEntity = _mapper.Map<Author>(author);

        _libraryRepository.AddAuthor(authorEntity);
        await _libraryRepository.SaveAsync();

        var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

        return CreatedAtRoute("GetAuthors",
            new { authorId = authorToReturn.Id },
            authorToReturn);
    }
}