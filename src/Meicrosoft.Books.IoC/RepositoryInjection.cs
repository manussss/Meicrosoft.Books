using Meicrosoft.Books.Domain.BooksAggregate;
using Meicrosoft.Books.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Books.IoC
{
    public static class RepositoryInjection
    {
        public static void AddRepositoriesInjection(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
        }
    }
}
