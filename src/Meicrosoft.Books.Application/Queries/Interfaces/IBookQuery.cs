using Meicrosoft.Books.Application.Queries.ViewModels;

namespace Meicrosoft.Books.Application.Queries.Interfaces
{
    public interface IBookQuery
    {
        Task<IEnumerable<BookSummarizeViewModel>> GetAllAsync();
    }
}
