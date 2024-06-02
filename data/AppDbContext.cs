using Microsoft.EntityFrameworkCore;
using models;

namespace Data;

public class AppDbContext : DbContext {
    
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }

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
