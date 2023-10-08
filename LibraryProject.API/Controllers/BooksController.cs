using AutoMapper;
using LibraryProject.API.Entities;
using LibraryProject.API.Models;
using LibraryProject.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.API.Controllers;

[ApiController]
[Route("api/authors/{authorId:guid}/books")]
public class BooksController : ControllerBase
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public BooksController(IMapper mapper, ILibraryRepository libraryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _libraryRepository = libraryRepository ?? throw new ArgumentNullException(nameof(libraryRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksForAuthor(Guid authorId)
    {
        if (!await _libraryRepository.AuthorExistsAsync(authorId)) return NotFound();

        var booksFromRepo = await _libraryRepository.GetBooksAsync(authorId);

        return Ok(_mapper.Map<IEnumerable<BookDto>>(booksFromRepo));
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBookForAuthor(Guid authorId, BookForCreationDto book)
    {
        if (!await _libraryRepository.AuthorExistsAsync(authorId)) return NotFound();

        var bookEntity = _mapper.Map<Book>(book);
        _libraryRepository.AddBook(authorId, bookEntity);
        await _libraryRepository.SaveAsync();

        var bookToReturn = _mapper.Map<BookDto>(bookEntity);

        return Ok(bookToReturn);
    }
}