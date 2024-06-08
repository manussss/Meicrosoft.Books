using MediatR;
using Meicrosoft.Books.Application.Contracts;

namespace Meicrosoft.Books.Application.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
