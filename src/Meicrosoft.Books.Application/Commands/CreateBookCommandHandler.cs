using MediatR;
using Meicrosoft.Books.Application.Contracts;
using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Commands
{
    public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                await bookRepository.CreateAsync(request.Book);

                //Business Rules
                //Audit Trail

                response.SetResponse(request.Book, true);
                
                return response;
            }
            catch (Exception ex)
            {
                response.SetResponse(null, false);
                
                return response;
            }
        }
    }
}
