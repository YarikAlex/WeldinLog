using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _db;

        public JobRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(Job entity)
        {
            await _db.Jobs.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Job[]> Select()
        {
            return await _db.Jobs.ToArrayAsync();
        }

        public async Task<bool> Delete(Job entity)
        {
            _db.Jobs.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}