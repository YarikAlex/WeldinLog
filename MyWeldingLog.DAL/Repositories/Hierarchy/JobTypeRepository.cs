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
        public async Task<bool> Insert(JobType entity)
        {
           await _db.JobTypes.AddAsync(entity);
           await _db.SaveChangesAsync();
           return true;
        }

        public async Task<JobType[]> Select()
        {
            return await _db.JobTypes.ToArrayAsync();
        }

        public async Task<bool> Delete(JobType entity)
        {
            _db.JobTypes.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}