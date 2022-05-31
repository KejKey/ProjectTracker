using Microsoft.EntityFrameworkCore;
using ProjectTracker.Api.Entities;

namespace ProjectTracker.Api.Data
{
    public class TrackerDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public TrackerDbContext(IConfiguration configuration) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("ProjectTrackerConnection"));
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Backlog> BacklogItems { get; set; }
        public DbSet<Bug> Bugs { get; set; }
    }
}
