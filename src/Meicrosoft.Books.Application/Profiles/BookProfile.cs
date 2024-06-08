using AutoMapper;
using Meicrosoft.Books.Application.DTOs;
using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
        }
    }
}
