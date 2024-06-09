using Meicrosoft.Books.Domain.BooksAggregate;
using Meicrosoft.Books.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Books.Infra.Repositories
{
    public class BookRepository(BookContext context) : IBookRepository
    {
        public async Task CreateAsync(Book book)
        {
            await context.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await context.Book.FindAsync(id);
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
