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
            await _db.Hierarchy.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Models.Hierarchy.Hierarchy[]> Select()
        {
            return await _db.Hierarchy.ToArrayAsync();
        }

        public async Task<bool> Delete(Models.Hierarchy.Hierarchy entity)
        {
            _db.Hierarchy.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}