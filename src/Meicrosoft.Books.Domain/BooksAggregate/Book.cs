using Meicrosoft.Books.Domain.Entities;

namespace Meicrosoft.Books.Domain.BooksAggregate
{
    public class Book : Entity
    {
        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
