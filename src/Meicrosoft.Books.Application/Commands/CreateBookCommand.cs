using MediatR;
using Meicrosoft.Books.Application.Contracts;

namespace Meicrosoft.Books.Application.Commands
{
    public class CreateBookCommand : IRequest<ResponseContract>
    {
    }
}
