using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.DAL.Interfaces.Hierarchy
{
    public interface IClusterRepository : IBaseRepository<Cluster>
    {
        Task<Cluster> GetByName(string name, CancellationToken token);

        Task<Cluster> Update(Cluster cluster, CancellationToken token);
    }
}