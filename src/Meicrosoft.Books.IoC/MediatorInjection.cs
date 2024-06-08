using MediatR;
using Meicrosoft.Books.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Books.IoC
{
    public static class MediatorInjection
    {
        public static void AddMediatorInjection(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBookCommand).Assembly));
        }
    }
}
