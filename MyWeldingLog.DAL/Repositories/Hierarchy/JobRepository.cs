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
        public async Task<bool> Insert(Job entity, CancellationToken token)
        {
            await _db.Jobs.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<Job[]> Select(CancellationToken token)
        {
            return await _db.Jobs.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(Job entity, CancellationToken token)
        {
            _db.Jobs.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }
    }
}