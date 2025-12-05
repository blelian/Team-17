using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConnectionsManager.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add DbSets for your pages
    public DbSet<Connection> Connections { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<Reminder> Reminders { get; set; } = null!;
}
