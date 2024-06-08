using Meicrosoft.Books.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Books.IoC
{
    public static class DatabaseInjection
    {
        public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookContext>(options => options.UseSqlServer(configuration.GetConnectionString("BookConnection")));
        }
    }
}
