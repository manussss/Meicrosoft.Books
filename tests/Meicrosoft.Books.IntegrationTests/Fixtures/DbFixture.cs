using Meicrosoft.Books.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Books.IntegrationTests.Fixtures
{
    public class DbFixture : IDisposable
    {
        private readonly BookContext _dbContext;
        public readonly string DatabaseName = $"MeicrosoftBook-{Guid.NewGuid()}";
        public readonly string ConnectionString;
        private bool _disposed;

        public DbFixture()
        {
            ConnectionString = $"Server=[::1];Database={DatabaseName};User=sa;Password=the_Real@riginal01;TrustServerCertificate=True";

            var builder = new DbContextOptionsBuilder<BookContext>();

            builder.UseSqlServer(ConnectionString);

            _dbContext = new BookContext(builder.Options);

            _dbContext.Database.Migrate();
            _dbContext.GetInfrastructure().GetRequiredService<IMigrator>().Migrate(Migration.InitialDatabase);
            _dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {

    }
}
