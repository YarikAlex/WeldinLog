using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Repositories.ProjectMaterials
{
    public class ProjectPipeMaterialRepository : IProjectPipeMaterialRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectPipeMaterialRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(ProjectPipeMaterial entity)
        {
            await _db.ProjectPipeMaterials.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectPipeMaterial[]> Select()
        {
           return await _db.ProjectPipeMaterials.ToArrayAsync();
        }

        public async Task<bool> Delete(ProjectPipeMaterial entity)
        {
            _db.ProjectPipeMaterials.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectPipeMaterial?> Get(int id)
        {
            var pipes = await _db.ProjectPipeMaterials.ToArrayAsync();
            var pipe = pipes.FirstOrDefault(p => p.Id == id);
            return pipe;
        }
    }
}