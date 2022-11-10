using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Repositories.ProjectMaterials
{
    public class ProjectBranchMaterialRepository : IProjectBranchMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectBranchMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(ProjectBranchMaterial entity)
        {
            await _db.ProjectBranchMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectBranchMaterial[]> Select()
        {
            return await _db.ProjectBranchMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(ProjectBranchMaterial entity)
        {
            _db.ProjectBranchMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectBranchMaterial?> Get(int id)
        {
            var branches = await _db.ProjectBranchMaterials.ToArrayAsync();
            var branch = branches.FirstOrDefault(p => p.Id == id);
            return branch;
        }
    }
}