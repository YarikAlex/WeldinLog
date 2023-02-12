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

        public async Task<bool> Insert(Object entity)
        {
            await _db.Objects.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Object[]> Select()
        {
            return await _db.Objects.ToArrayAsync();
        }

        public async Task<bool> Delete(Object entity)
        {
            _db.Objects.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Object?> Get(int id)
        {
            var objects = await _db.Objects.ToArrayAsync();
            var result = objects.FirstOrDefault(o => o.Id == id);
            return result;
        }

        public async Task<EntityEntry<Object>> Update(Object obj)
        {
           var result = _db.Objects.Update(obj);
           await _db.SaveChangesAsync();
           return result;
        }
    }
}