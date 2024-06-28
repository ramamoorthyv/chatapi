using Microsoft.EntityFrameworkCore;
using chatapi.Models;

namespace chatapi.Data;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Message> Messages { get; set; }
}

