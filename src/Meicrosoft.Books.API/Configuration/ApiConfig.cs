using Meicrosoft.Books.API.Middlewares;

namespace Meicrosoft.Books.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseApiVersioning();
            app.UseRouting();
            app.MapControllers();
            app.UseSwagger();
            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI();
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
