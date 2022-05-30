using Microsoft.EntityFrameworkCore;
using ProjectTracker.Api.Entities;

namespace ProjectTracker.Api.Data
{
    public class ProjectTrackerDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProjectTrackerDbContext(IConfiguration configuration) => Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("ProjectTrackerConnection"));
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Backlog> BacklogItem { get; set; }
        public DbSet<Bug> Bugs { get; set; }
    }
}
