
using Microsoft.EntityFrameworkCore;
using Npgsql;
// [key]
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Entity Framework
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
        // ---
        
        // CORS
        builder.Services.AddCors();
        // ---

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // CORS
            app.UseCors(builder => builder.AllowAnyOrigin());
        }

        app.UseHttpsRedirection();

        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();


        app.MapGet("/weather", () =>
        {
            // var fr = Enumerable.Range(1, 1).Select(index =>
            //     new Wet(5))
            //     .ToArray();
            Wet[] frr = [new Wet(5), new Wet(6)];
            return frr;
        });

        // Соединение с базой простое
        // var connectionString = "Host=127.0.0.1;Username=user;Password=password;Database=coursesdb";
        // await using var dataSource = NpgsqlDataSource.Create(connectionString);
        // await using var command = dataSource.CreateCommand("select surname from users");
        // await using var reader = await command.ExecuteReaderAsync();
        // while (await reader.ReadAsync())
        // {
        //     Console.WriteLine(reader.GetString(0));
        // }

        // Entity Framework
        app.MapGet("/dep", (ApplicationContext db) => db.departments.ToList());


        app.Run();
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF
    {
        get
        {
            return 32 + (int)(TemperatureC / 0.5556);
        }
    }
}

class Wet
{
    public int Temp
    {
        get;
    }
    public Wet(int w)
    {
        Temp = w;
    }
}

// Entity Framework
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options)
            : base(options)
    {
    }
    public DbSet<Departments> departments { get; set; }
}
// Entity Framework
public class Departments
{
    [Key]
    public int id_department { get; set; }
    [Required]
    [MaxLength(150)]
    public string? dep_name { get; set; }
    [Required]
    [MaxLength(150)]
    public string? dep_manager { get; set; }
}