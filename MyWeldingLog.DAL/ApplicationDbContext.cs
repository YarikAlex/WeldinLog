using Microsoft.EntityFrameworkCore;
using MyWeldingLog.Models.ActualMaterials;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.InboundMaterials;
using MyWeldingLog.Models.ProjectMaterials;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<ProjectBranchMaterial> ProjectBranchMaterials { get; set; }
        public DbSet<ProjectPipeMaterial> ProjectPipeMaterials { get; set; }
        public DbSet<InboundPipeMaterial> InboundPipeMaterials { get; set; }
        public DbSet<InboundBranchMaterial> InboundBranchMaterials { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<SubObject> SubObjects { get; set; }
        public DbSet<ProjectCode> ProjectCodes { get; set; }
        public DbSet<Hierarchy> Hierarchies { get; set; }
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