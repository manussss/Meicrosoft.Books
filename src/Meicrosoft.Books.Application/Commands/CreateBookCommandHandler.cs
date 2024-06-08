using MediatR;
using Meicrosoft.Books.Application.Contracts;
using Meicrosoft.Books.Domain.BooksAggregate;
using Serilog;

namespace Meicrosoft.Books.Application.Commands
{
    public class CreateBookCommandHandler(IBookRepository bookRepository, ILogger logger) : IRequestHandler<CreateBookCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                await bookRepository.CreateAsync(request.Book);

                //Set / Control Business Rules
                //Audit Trail

                response.SetResponse(request.Book, true);
                
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method}", nameof(CreateBookCommandHandler), nameof(Handle));

                response.SetResponse(null, false);
                
                return response;
            }
        }
    }
}
