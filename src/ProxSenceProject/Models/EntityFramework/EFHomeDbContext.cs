using Microsoft.EntityFrameworkCore;

namespace ProxSenceProject.Models.EntityFramework
{
    public class EFHomeDbContext : DbContext
    {
        public EFHomeDbContext(DbContextOptions<EFHomeDbContext> options) : base(options) { }
        public DbSet<News> NewsData { get; set; }
    }
}
