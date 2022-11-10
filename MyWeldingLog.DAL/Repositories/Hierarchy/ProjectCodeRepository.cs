using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class ProjectCodeRepository : IProjectCodeRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectCodeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(ProjectCode entity)
        {
            await _db.ProjectCodes.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectCode[]> Select()
        {
            return await _db.ProjectCodes.ToArrayAsync();
        }

        public async Task<bool> Delete(ProjectCode entity)
        {
            _db.ProjectCodes.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectCode?> Get(int id)
        {
            var projectCodes = await _db.ProjectCodes.ToArrayAsync();
            var result = projectCodes.FirstOrDefault(o => o.Id == id);
            return result;
        }
    }
}