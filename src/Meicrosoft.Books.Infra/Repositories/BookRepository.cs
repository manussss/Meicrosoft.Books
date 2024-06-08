using Meicrosoft.Books.Domain.BooksAggregate;
using Meicrosoft.Books.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Books.Infra.Repositories
{
    public class BookRepository(BookContext context) : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Book.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await context.Book.FindAsync(id);
        }

        public async Task UpdateBook(Book book)
        {
            context.Book.Update(book);
            await context.SaveChangesAsync();
        }
    }
}
