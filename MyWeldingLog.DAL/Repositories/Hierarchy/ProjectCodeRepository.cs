using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class ProjectCodeRepository : IProjectCodeRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectCodeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(
            ProjectCode entity,
            CancellationToken token)
        {
            await _db.ProjectCodes.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<ProjectCode[]> Select(CancellationToken token)
        {
            return await _db.ProjectCodes.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(ProjectCode entity, CancellationToken token)
        {
            _db.ProjectCodes.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<ProjectCode?> Get(
            int id,
            CancellationToken token)
        {
            var projectCodes = await _db.ProjectCodes.ToArrayAsync(cancellationToken: token);
            var result = projectCodes.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public async Task<EntityEntry<ProjectCode>> Update(
            ProjectCode entity,
            CancellationToken token)
        {
            var result = _db.ProjectCodes.Update(entity);
            await _db.SaveChangesAsync(token);
            return result;
        }
    }
}