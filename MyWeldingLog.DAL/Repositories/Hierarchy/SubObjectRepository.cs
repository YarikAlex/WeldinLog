using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class SubObjectRepository : ISubObjectRepository
    {
        private readonly ApplicationDbContext _db;

        public SubObjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(
            SubObject entity,
            CancellationToken token)
        {
            await _db.SubObjects.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<SubObject[]> Select(CancellationToken token)
        {
            return await _db.SubObjects.ToArrayAsync(token);
        }

        public async Task<bool> Delete(
            SubObject entity,
            CancellationToken token)
        {
            _db.SubObjects.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<SubObject?> Get(
            int id,
            CancellationToken token)
        {
            var subObjects = await _db.SubObjects.ToArrayAsync(cancellationToken: token);
            var result = subObjects.FirstOrDefault(s => s.Id == id);
            return result;
        }

        public async Task<EntityEntry<SubObject>> Update(
            SubObject entity, CancellationToken token)
        {
            var result = _db.SubObjects.Update(entity);
            await _db.SaveChangesAsync(token);
            return result;
        }
    }
}