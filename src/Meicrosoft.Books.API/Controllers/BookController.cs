using AutoMapper;
using MediatR;
using Meicrosoft.Books.Application.Commands;
using Meicrosoft.Books.Application.DTOs;
using Meicrosoft.Books.Application.Queries.Interfaces;
using Meicrosoft.Books.Domain.BooksAggregate;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Meicrosoft.Books.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/books")]
    public class BookController(IMediator mediator, IMapper mapper, Serilog.ILogger logger, IBookQuery bookQuery) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBookDto dto)
        {
            logger.Information("{Class} | {Method} | {Parameters}", nameof(BookController), nameof(CreateAsync), JsonSerializer.Serialize(dto));

            var result = await mediator.Send(new CreateBookCommand(mapper.Map<Book>(dto)));

            return result.Success ? Created(nameof(CreateAsync), result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await bookQuery.GetAllAsync());
        }
    }
}
