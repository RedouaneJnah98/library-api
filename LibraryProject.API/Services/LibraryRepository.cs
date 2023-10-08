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

    public async Task<IEnumerable<Book>> GetBooksAsync(Guid authorId)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        return await _context.Books
            .Where(b => b.AuthorId == authorId)
            .OrderBy(b => b.Title)
            .ToListAsync();
    }

    public async Task<Book> GetBookAsync(Guid authorId, Guid bookId)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        if (bookId == Guid.Empty) throw new ArgumentNullException(nameof(bookId));

#pragma warning disable CS8603
        return await _context.Books
            .Where(b => b.AuthorId == authorId && b.Id == bookId)
            .FirstOrDefaultAsync();
#pragma warning restore CS8603
    }

    public void AddBook(Guid authorId, Book book)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        if (book == null) throw new ArgumentNullException(nameof(book));

        book.AuthorId = authorId;
        _context.Books.Add(book);
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
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

#pragma warning disable CS8603
        return await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
#pragma warning restore CS8603
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
        if (author == null) throw new ArgumentNullException(nameof(author));
    }

    public void DeleteAuthor(Author author)
    {
        _context.Authors.Remove(author);
    }

    public async Task<bool> AuthorExistsAsync(Guid authorId)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        return await _context.Authors.AnyAsync(a => a.Id == authorId);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}