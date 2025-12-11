using Microsoft.EntityFrameworkCore;
using Notices.Domain.Entities;
namespace Notices.Infrastructure.Database;

public class NoticesDbContext(DbContextOptions<NoticesDbContext> options) : DbContext(options)
{
    public DbSet<Notice> Notices { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoticesDbContext).Assembly);
    }
}