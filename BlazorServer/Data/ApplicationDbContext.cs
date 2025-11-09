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
    }
}
