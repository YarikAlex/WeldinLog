using Microsoft.EntityFrameworkCore;
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

        public async Task Insert(Object entity)
        {
            await _db.Objects.AddAsync(entity);
            await _db.SaveChangesAsync();
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

        public Task Update(Object entity)
        {
            throw new NotImplementedException();
        }
    }
}