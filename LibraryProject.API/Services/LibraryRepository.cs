using LibraryProject.API.DbContexts;
using LibraryProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.API.Services;

public class LibraryRepository : ILibraryRepository
{
    private readonly LibraryContext _context;

    public LibraryRepository(LibraryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Book> GetBookAsync(Guid authorId, Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void AddBook(Guid authorId, Book book)
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public void AddAuthor(Author author)
    {
        if (author == null) throw new ArgumentNullException(nameof(author));

        author.Id = Guid.NewGuid();
        foreach (var book in author.Books) book.Id = Guid.NewGuid();
        _context.Authors.Add(author);
    }

    public void UpdateAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AuthorExistsAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}