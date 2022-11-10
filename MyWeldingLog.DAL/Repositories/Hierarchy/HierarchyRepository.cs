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

        public async Task<bool> Insert(Models.Hierarchy.Hierarchy entity)
        {
            await _db.Hierarchies.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Models.Hierarchy.Hierarchy[]> Select()
        {
            return await _db.Hierarchies.ToArrayAsync();
        }

        public async Task<bool> Delete(Models.Hierarchy.Hierarchy entity)
        {
            _db.Hierarchies.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}