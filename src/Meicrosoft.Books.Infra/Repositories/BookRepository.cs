using Meicrosoft.Books.Domain.BooksAggregate;
using Meicrosoft.Books.Infra.Data;

namespace Meicrosoft.Books.Infra.Repositories
{
    public class BookRepository(BookContext context) : IBookRepository
    {
        public async Task CreateAsync(Book book)
        {
            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            context.Book.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            context.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
