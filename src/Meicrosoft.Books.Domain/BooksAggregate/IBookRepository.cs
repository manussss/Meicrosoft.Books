namespace Meicrosoft.Books.Domain.BooksAggregate
{
    public interface IBookRepository
    {
        Task CreateAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(Guid id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}
