using Microsoft.EntityFrameworkCore;
using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Repositories.Hierarchy
{
    public class ClusterRepository : IClusterRepository
    {
        private readonly ApplicationDbContext _db;

        public ClusterRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Insert(Cluster entity)
        {
            await _db.Clusters.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Cluster[]> Select()
        {
            return await _db.Clusters.ToArrayAsync();
        }

        public async Task<bool> Delete(Cluster entity)
        {
            _db.Clusters.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}