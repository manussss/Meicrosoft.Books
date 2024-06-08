using AutoMapper;
using MediatR;
using Meicrosoft.Books.Application.Commands;
using Meicrosoft.Books.Application.DTOs;
using Meicrosoft.Books.Domain.BooksAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Meicrosoft.Books.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/books")]
    public class BookController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBookDto dto)
        {
            var result = await mediator.Send(new CreateBookCommand(mapper.Map<Book>(dto)));

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
