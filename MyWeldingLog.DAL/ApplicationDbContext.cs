using Microsoft.EntityFrameworkCore;
using MyWeldingLog.Models.ActualMaterials;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.ProjectMaterials;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<ProjectBranchMaterial> ProjectBranchMaterials { get; set; }
        public DbSet<ProjectPipeMaterial> ProjectPipeMaterials { get; set; }
        public DbSet<ActualPipeMaterial> ActualPipeMaterials { get; set; }
        public DbSet<ActualBranchMaterial> ActualBranchMaterials { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<SubObject> SubObjects { get; set; }
        public DbSet<ProjectCode> ProjectCodes { get; set; }
        
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