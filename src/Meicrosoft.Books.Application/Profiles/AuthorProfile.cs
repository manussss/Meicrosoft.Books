using AutoMapper;
using Meicrosoft.Books.Application.DTOs;
using Meicrosoft.Books.Domain.BooksAggregate;

namespace Meicrosoft.Books.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorDto, Author>();
        }
    }
}
