using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Queries.ViewModels
{
    public class BookSummarizeViewModel
    {
        public AuthorSummarizeViewModel Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
