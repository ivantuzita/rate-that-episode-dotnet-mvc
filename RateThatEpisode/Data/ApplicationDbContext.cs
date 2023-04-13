using Microsoft.EntityFrameworkCore;
using RateThatEpisode.Models;

namespace RateThatEpisode.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }

        public DbSet<Episode> Episodes { get; set; }

    }
}
