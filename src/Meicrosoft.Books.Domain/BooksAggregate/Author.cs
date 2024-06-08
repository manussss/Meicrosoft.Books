using Meicrosoft.Books.Domain.Entities;

namespace Meicrosoft.Books.Domain.BooksAggregate
{
    public class Author : Entity
    {
        public string Name { get; private set; }
        public IReadOnlyCollection<Book> Books => _books;
        private readonly List<Book> _books;

        public Author()
        {
            _books = new();
        }
    }
}
