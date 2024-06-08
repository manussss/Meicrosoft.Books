using Meicrosoft.Books.Domain.BooksAggregate;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Books.Infra.Data
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BookContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
