using Microsoft.EntityFrameworkCore;
using chatapi.Models;

namespace chatapi.Data;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      // Configure relationships
        modelBuilder.Entity<Message>()
            .HasOne(m => m.FromUser)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.From)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

        modelBuilder.Entity<Message>()
            .HasOne(m => m.ToUser)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.To)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete
    }
}

