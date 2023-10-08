using LibraryProject.API.Entities;

namespace LibraryProject.API.Services;

public interface ILibraryRepository
{
    Task<IEnumerable<Book>> GetBooksAsync(Guid authorId);
    Task<Book> GetBookAsync(Guid authorId, Guid bookId);
    void AddBook(Guid authorId, Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> GetAuthorAsync(Guid authorId);
    void AddAuthor(Author author);
    void UpdateAuthor(Author author);
    void DeleteAuthor(Author author);
    Task<bool> AuthorExistsAsync(Guid authorId);
    Task<bool> SaveAsync();
}