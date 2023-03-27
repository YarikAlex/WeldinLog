using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class ObjectRepository : IObjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ObjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Insert(Object entity, CancellationToken token)
        {
            await _db.Objects.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<IEnumerable<Object>> Select(CancellationToken token)
        {
            return await _db.Objects.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(Object entity, CancellationToken token)
        {
            _db.Objects.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<Object?> Get(int id, CancellationToken token)
        {
            var objects = await _db.Objects.ToArrayAsync(cancellationToken: token);
            var result = objects.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public async Task<EntityEntry<Object>> Update(Object obj, CancellationToken token)
        {
           var result = _db.Objects.Update(obj);
           await _db.SaveChangesAsync(token);
           return result;
        }
    }
}