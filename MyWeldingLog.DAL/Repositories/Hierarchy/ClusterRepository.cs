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
        public async Task<bool> Insert(Cluster entity, CancellationToken token)
        {
            await _db.Clusters.AddAsync(entity, token);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<IEnumerable<Cluster>> Select(CancellationToken token)
        {
            return await _db.Clusters.ToArrayAsync(cancellationToken: token);
        }

        public async Task<bool> Delete(Cluster entity, CancellationToken token)
        {
            _db.Clusters.Remove(entity);
            await _db.SaveChangesAsync(token);
            return true;
        }

        public async Task<Cluster> GetByName(string name, CancellationToken token)
        {
            var clusters = await _db.Clusters
                .Where(x => x.Name == name)
                .ToArrayAsync(token);

            var cluster = clusters.FirstOrDefault();
            return cluster;
        }

        public async Task<Cluster> Update(Cluster cluster, CancellationToken token)
        {
            var result = _db.Clusters.Update(cluster);
            await _db.SaveChangesAsync(token);

            return result.Entity;
        }
    }
}