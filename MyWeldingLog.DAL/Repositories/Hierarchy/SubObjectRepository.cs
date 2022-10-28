using Microsoft.EntityFrameworkCore;
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
        public async Task Insert(SubObject entity)
        {
            await _db.SubObjects.AddAsync(entity);
        }

        public async Task<SubObject[]> Select()
        {
            return await _db.SubObjects.ToArrayAsync();
        }

        public async Task<bool> Delete(SubObject entity)
        {
            _db.SubObjects.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task Update(SubObject entity)
        {
            throw new NotImplementedException();
        }
    }
}