using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class HierarchyRepository : IHierarchyRepository
    {
        private readonly ApplicationDbContext _db;

        public HierarchyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(
            Models.Hierarchy.Hierarchy entity,
            CancellationToken token)
        {
            await _db.Hierarchy.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<Models.Hierarchy.Hierarchy[]> Select(CancellationToken token)
        {
            return await _db.Hierarchy.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(
            Models.Hierarchy.Hierarchy entity,
            CancellationToken token)
        {
            _db.Hierarchy.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }
    }
}