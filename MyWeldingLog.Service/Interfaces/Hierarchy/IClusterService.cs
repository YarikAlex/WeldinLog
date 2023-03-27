using MyWeldingLog.Models.Hierarchy;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IClusterService
    {
        Task<bool> CreateNewCluster(
            string objectName,
            string subObjectName,
            string clusterName,
            CancellationToken token);

        Task<bool> DeleteCluster(string clusterName, CancellationToken token);

        Task<Cluster> GetClusterByName(string name, CancellationToken token);

        Task<bool> RenameCluster(string currentName, string newName, CancellationToken token);
    }
}