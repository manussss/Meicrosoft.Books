using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.DTOs
{
    public class CreateBookDto
    {
        public CreateAuthorDto Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
