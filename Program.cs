using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
// using MyClientNamespace;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder= WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        // define middleware usage
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        app.MapControllers();


        // Uncomment the following lines to generate the client code after the application starts

        Task.Run(() => app.RunAsync());
        Task.Delay(2000);
        await new SwaggerClientGenerator().GenerateClient();

        // Uncomment the following lines to use the generated client    

        // var httpClient = new HttpClient();
        // var client = new CustomApiClient(httpClient);
        // var user = await client.GetUserAsync(1);
        // Console.WriteLine($"User ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
        // app.Run();
    }
}


