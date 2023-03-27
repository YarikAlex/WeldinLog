using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Service.Exceptions;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Service.Implementations.Hierarchy
{
    public class HierarchyService : IHierarchyService
    {
        private readonly IHierarchyRepository _hierarchyRepository;
        private readonly IObjectService _objectService;
        private readonly ISubObjectService _subObjectService;

        public HierarchyService(
            IHierarchyRepository hierarchyRepository,
            IObjectService objectService,
            ISubObjectService subObjectService)
        {
            _hierarchyRepository = hierarchyRepository;
            _objectService = objectService;
            _subObjectService = subObjectService;
        }

        public async Task<bool> AddNewSubObjectInObject(
            string objectName,
            string subObjectName,
            CancellationToken token)
        {
            var obj = await _objectService.GetObjectByName(objectName, token);
            var subObject = await _subObjectService.GetSubObjectByName(subObjectName, token);

            var hierarchies = await _hierarchyRepository.Select(token);
            var hierarchy = hierarchies.FirstOrDefault(
                x =>
                    x.ObjectId == obj.Id &&
                    x.SubObjectId == subObject.Id);

            if (hierarchy != null)
            {
                throw new LinkAlreadyExistException(objectName, subObjectName);
            }

            var response = await _hierarchyRepository.Insert(
                entity: new Models.Hierarchy.Hierarchy 
                {
                    ObjectId = obj.Id,
                    SubObjectId = subObject.Id
                },
                token);
            
            return response;
        }

        public async Task<bool> DeleteSubObjectFromObject(
            string objectName,
            string subObjectName,
            CancellationToken token)
        {
            var obj = await _objectService.GetObjectByName(objectName, token);
            var subObject = await _subObjectService.GetSubObjectByName(subObjectName, token);

            var hierarchies = await _hierarchyRepository.Select(token);

            var hierarchy = hierarchies.FirstOrDefault(x => 
                x.ObjectId == obj.Id &&
                x.SubObjectId == subObject.Id);

            if (hierarchy == null)
            {
                throw new LinkNotFoundException(objectName, subObjectName);
            }
            
            var response = await _hierarchyRepository.Delete(hierarchy, token);
            
            return response;
        }

        public async Task<int> GetHierarchyId(
            int objectId,
            int subObjectId,
            CancellationToken token)
        {
            var hierarchies = await _hierarchyRepository.Select(token);
            var hierarchy = hierarchies.FirstOrDefault(x => 
                x.ObjectId == objectId && 
                x.SubObjectId == subObjectId);

            if (hierarchy == null)
            {
                throw new LinkNotFoundException(objectId, subObjectId);
            }

            return hierarchy.Id;
        }
    }
}