using MediatR;
using Meicrosoft.Books.Application.Contracts;
using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Commands
{
    public class CreateBookCommand : IRequest<ResponseContract>
    {
        public Book Book { get; set; }

        public CreateBookCommand(Book book)
        {
            Book = book;
        }
    }
}
