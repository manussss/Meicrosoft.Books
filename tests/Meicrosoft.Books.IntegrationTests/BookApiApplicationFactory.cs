using Meicrosoft.Books.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Meicrosoft.Books.IntegrationTests
{
    [Collection("Database")]
    public class BookApiApplicationFactory(DbFixture dbFixture) : WebApplicationFactory<Program>
    {

    }
}
