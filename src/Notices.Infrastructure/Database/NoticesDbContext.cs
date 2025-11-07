using Microsoft.EntityFrameworkCore;
using Notices.Domain.Entities;
namespace Notices.Infrastructure.Database;

public class NoticesDbContext(DbContextOptions<NoticesDbContext> options) : DbContext(options)
{
    public DbSet<Notice> Notices { get; set; }
}