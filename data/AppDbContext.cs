using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connectionString);
    }
}
