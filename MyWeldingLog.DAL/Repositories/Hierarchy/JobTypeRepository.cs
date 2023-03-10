using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public JobTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(JobType entity, CancellationToken token)
        {
           await _db.JobTypes.AddAsync(entity, token);
           await _db.SaveChangesAsync(token);
           return true;
        }

        public async Task<JobType[]> Select(CancellationToken token)
        {
            return await _db.JobTypes.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(JobType entity, CancellationToken token)
        {
            _db.JobTypes.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }
    }
}