
using dot_net_8_jwt_authentication_api.Services.User;

namespace dot_net_8_jwt_authentication_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new instance of the WebApplicationBuilder to build the application
            var builder = WebApplication.CreateBuilder(args);

            // Add the controllers to the services collection
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Add Swagger generation to the services collection
            builder.Services.AddSwaggerGen();

            // Add a scoped instance of the UserService
            builder.Services.AddScoped<IUserService, UserService>();

            // Build the application
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger and Swagger UI in development environment
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable authorization
            app.UseAuthorization();

            // Map the controllers to their corresponding routes
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
