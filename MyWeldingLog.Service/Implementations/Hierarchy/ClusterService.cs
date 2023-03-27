using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Service.Exceptions;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class ClusterService : IClusterService
    {
        private readonly IClusterRepository _clusterRepository;
        private readonly IObjectService _objectService;
        private readonly ISubObjectService _subObjectService;
        private readonly IHierarchyService _hierarchyService;

        public ClusterService(
            IClusterRepository clusterRepository,
            IObjectService objectService,
            ISubObjectService subObjectService,
            IHierarchyService hierarchyService)
        {
            _clusterRepository = clusterRepository;
            _objectService = objectService;
            _subObjectService = subObjectService;
            _hierarchyService = hierarchyService;
        }

        public async Task<bool> CreateNewCluster(
            string objectName,
            string subObjectName,
            string clusterName,
            CancellationToken token)
        {
            var objectId = (await _objectService.GetObjectByName(objectName, token)).Id;
            var subObjectId = (await _subObjectService.GetSubObjectByName(subObjectName, token)).Id;
            var hierarchyId = await _hierarchyService.GetHierarchyId(objectId, subObjectId, token);

            var clusters = (await _clusterRepository.Select(token))
                .Select(x => x.Name)
                .ToArray();

            if (clusters.Contains(clusterName))
            {
                throw new ClusterAlreadyExistException(objectName, subObjectName, clusterName);
            }

            return await _clusterRepository.Insert(
                new Cluster
                {
                    HierarchyId = hierarchyId,
                    Name = clusterName
                },
                token);
        }

        public async Task<bool> DeleteCluster(
            string clusterName,
            CancellationToken token)
        {
            var cluster = await _clusterRepository.GetByName(clusterName, token);
            if (cluster is null)
            {
                throw new ClusterNotFoundException(clusterName);
            }

            return await _clusterRepository.Delete(cluster, token);
        }

        public async Task<Cluster> GetClusterByName(
            string name,
            CancellationToken token)
        {
            var cluster = await _clusterRepository.GetByName(name, token);
            if (cluster == null)
            {
                throw new ClusterNotFoundException(name);
            }

            return cluster;
        }

        public async Task<bool> RenameCluster(
            string currentName,
            string newName, CancellationToken token)
        {
            var cluster = await _clusterRepository.GetByName(currentName, token);
            if (cluster == null)
            {
                throw new ClusterNotFoundException(currentName);
            }

            cluster.Name = newName;
            var response = await _clusterRepository.Update(cluster, token);
            return response.Name == newName;
        }
    }
}