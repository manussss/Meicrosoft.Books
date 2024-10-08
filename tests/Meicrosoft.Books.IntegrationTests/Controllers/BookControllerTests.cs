﻿using Azure.Core;
using Meicrosoft.Books.Application.DTOs;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Meicrosoft.Books.IntegrationTests.Controllers
{
    [Collection("Database")]
    public class BookControllerTests(BookApiApplicationFactory applicationFactory) : IClassFixture<BookApiApplicationFactory>
    {
        [Fact]
        public async Task CreateBook_ShouldReturn_BadRequest()
        {
            //Arrange
            var client = applicationFactory.CreateClient();
            var request = JsonSerializer.Serialize(new CreateBookDto());

            //Act
            var response = await client.PostAsync("api/v1/books", new StringContent(request, Encoding.UTF8, "application/json"));

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateBook_ShouldReturn_Created()
        {
            //Arrange
            var client = applicationFactory.CreateClient();
            var book = new CreateBookDto()
            {
                Author = new CreateAuthorDto
                {
                    Name = ""
                },
                Description = "Description",
                Title = "Title"
            };
            var request = JsonSerializer.Serialize(book);

            //Act
            var response = await client.PostAsync("api/v1/books", new StringContent(request, Encoding.UTF8, "application/json"));

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturn_Ok()
        {
            //Arrange
            var client = applicationFactory.CreateClient();

            //Act
            var response = await client.GetAsync("api/v1/books");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ShouldReturn_Ok()
        {
            //Arrange
            var client = applicationFactory.CreateClient();

            //Act
            var response = await client.GetAsync($"api/v1/books/{Guid.NewGuid()}");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
