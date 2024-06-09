namespace Meicrosoft.Books.Domain.BooksAggregate
{
    public interface IBookRepository
    {
        Task CreateAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}
