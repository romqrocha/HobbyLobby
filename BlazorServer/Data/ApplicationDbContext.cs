using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Hobby> Hobbies => Set<Hobby>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<ApplicationUser>()
            .HasOne(u => u.FavoriteHobby1)
            .WithMany(h => h.Favorite1Users)
            .HasForeignKey(u => u.FavoriteHobby1Id);

        modelBuilder
            .Entity<ApplicationUser>()
            .HasOne(u => u.FavoriteHobby2)
            .WithMany(h => h.Favorite2Users)
            .HasForeignKey(u => u.FavoriteHobby2Id);

        modelBuilder
            .Entity<ApplicationUser>()
            .HasOne(u => u.FavoriteHobby3)
            .WithMany(h => h.Favorite3Users)
            .HasForeignKey(u => u.FavoriteHobby3Id);

        // Unique username
        modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.UserName).IsUnique();

        // Unique BCIT email
        modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.BcitEmail).IsUnique();

        // Unique email
        modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.Email).IsUnique();

        // Seed the DB with Hobby data
        modelBuilder.Entity<Hobby>().HasData(GetHobbies());
    }

    /// <summary>
    /// Gets the hobby data from hobbyData.csv and enters it in the database.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<Hobby> GetHobbies()
    {
        string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "hobbyData.csv" };
        var csvFilePath = Path.Combine(p);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
        };

        var data = new List<Hobby>().AsEnumerable();
        using (var reader = new StreamReader(csvFilePath))
        {
            using (var csvReader = new CsvReader(reader, config))
            {
                data = csvReader.GetRecords<Hobby>().ToList();
            }
        }
        return data;
    }
}
