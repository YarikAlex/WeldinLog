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
        public async Task<bool> Insert(ProjectMaterial entity, CancellationToken token)
        {
            await _db.ProjectMaterials.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<IEnumerable<ProjectMaterial>> Select(CancellationToken token)
        {
            return await _db.ProjectMaterials.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(ProjectMaterial entity, CancellationToken token)
        {
            _db.ProjectMaterials.Update(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> InsertProjectMaterials(IEnumerable<ProjectMaterial> entities, CancellationToken token)
        {
            await _db.ProjectMaterials.AddRangeAsync(entities, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> DeleteProjectMaterials(IEnumerable<ProjectMaterial> entities, CancellationToken token)
        {
            _db.ProjectMaterials.UpdateRange(entities);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<ProjectMaterial?> GetById(int id, CancellationToken token)
        {
            var materials = await _db.ProjectMaterials.ToArrayAsync(token);
            return materials.FirstOrDefault(material => material.Id == id);
        }
    }
}