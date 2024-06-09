using Dapper;
using Meicrosoft.Books.Application.Queries.Interfaces;
using Meicrosoft.Books.Application.Queries.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Meicrosoft.Books.Application.Queries
{
    public class BookQuery(IConfiguration configuration, Serilog.ILogger logger) : IBookQuery
    {
        public async Task<IEnumerable<BookSummarizeViewModel>> GetAllAsync()
        {
            IEnumerable<BookSummarizeViewModel> summarizedBooks = new List<BookSummarizeViewModel>();

            try
            {
                var query = @"
                    select 
	                    b.Title,
	                    b.Description,
	                    a.Name 
                    from MeicrosoftBook.dbo.Book b 
                    inner join MeicrosoftBook.dbo.Author a 
                    on b.AuthorId = a.Id
                ";

                using (var connection = new SqlConnection(configuration.GetConnectionString("BookConnection")))
                {
                    summarizedBooks = await connection.QueryAsync<BookSummarizeViewModel, AuthorSummarizeViewModel, BookSummarizeViewModel>(
                        query,
                        (book, author) =>
                        {
                            book.Author = author;
                            return book;
                        },
                        splitOn: "Name");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method}", nameof(BookQuery), nameof(GetAllAsync));
            }

            return summarizedBooks;
        }

        public async Task<BookSummarizeViewModel?> GetByIdAsync(Guid id)
        {
            BookSummarizeViewModel? summarizedBook = new();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var query = @"
                    select 
	                    b.Title,
	                    b.Description,
	                    a.Name 
                    from MeicrosoftBook.dbo.Book b 
                    inner join MeicrosoftBook.dbo.Author a 
                    on b.AuthorId = a.Id
                    where b.Id = @Id
                ";

                using (var connection = new SqlConnection(configuration.GetConnectionString("BookConnection")))
                {
                    summarizedBook = (await connection.QueryAsync<BookSummarizeViewModel, AuthorSummarizeViewModel, BookSummarizeViewModel>(
                        query,
                        (book, author) =>
                        {
                            book.Author = author;
                            return book;
                        },
                        parameters,
                        splitOn: "Name"))
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "{Class} | {Method}", nameof(BookQuery), nameof(GetByIdAsync));
            }

            return summarizedBook;
        }
    }
}
