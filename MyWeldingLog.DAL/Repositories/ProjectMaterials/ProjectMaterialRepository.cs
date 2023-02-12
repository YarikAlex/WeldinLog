using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Repositories.ProjectMaterials
{
    public class ProjectMaterialRepository : IProjectMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(ProjectMaterial entity)
        {
            await _db.ProjectMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectMaterial[]> Select()
        {
            return await _db.ProjectMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(ProjectMaterial entity)
        {
            _db.ProjectMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> InsertProjectMaterials(ProjectMaterial[] entities)
        {
            await _db.ProjectMaterials.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectMaterials(ProjectMaterial[] entities)
        {
            _db.ProjectMaterials.UpdateRange(entities);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectMaterial?> GetById(int id)
        {
            var materials = await _db.ProjectMaterials.ToArrayAsync();
            return materials.FirstOrDefault(material => material.Id == id);
        }
    }
}