using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Contracts
{
    public class ResponseContract
    {
        public Book? Book { get; private set; }
        public bool Success { get; private set; }

        public void SetResponse(Book? book, bool success)
        {
            Book = book;
            Success = success;
        }
    }
}
