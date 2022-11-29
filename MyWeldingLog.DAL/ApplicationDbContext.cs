using Microsoft.EntityFrameworkCore;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.ProjectMaterials;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Object> Objects { get; set; }
        public DbSet<SubObject> SubObjects { get; set; }
        public DbSet<ProjectCode> ProjectCodes { get; set; }
        public DbSet<Hierarchy> Hierarchies { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<ProjectMaterial> ProjectMaterials { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}