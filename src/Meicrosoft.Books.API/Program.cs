using Meicrosoft.Books.API.Configuration;
using Meicrosoft.Books.Application.Profiles;
using Meicrosoft.Books.IoC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatorInjection();
builder.Services.AddDatabaseInjection(builder.Configuration);
builder.Services.AddRepositoriesInjection();
builder.Services.AddAutoMapper(typeof(BookProfile));

var app = builder.Build();
app.UseApiConfiguration(app.Environment);
app.Run();
