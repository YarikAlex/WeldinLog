using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
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

        public async Task<IBaseResponse<bool>> AddNewSubObjectInObject(
            string? objectName,
            string subObjectName,
            CancellationToken token)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var obj = await _objectService.GetObjectByName(objectName, token);
                var subObject = await _subObjectService.GetSubObjectByName(subObjectName, token);

                if (obj == null || subObject.Data == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Object or SubObject not found",
                        StatusCode = StatusCode.ObjectNotFound
                    };
                }
                
                var hierarchies = await _hierarchyRepository.Select(token);
                var hierarchy = hierarchies.FirstOrDefault(
                    x =>
                        x.ObjectId == obj.Id &&
                        x.SubObjectId == subObject.Data.Id);

                if (hierarchy != null)
                {
                    response.Description = "Link already exists";
                    response.StatusCode = StatusCode.LinkAlreadyExist;
                    return response;
                }
                
                var newLine = new Models.Hierarchy.Hierarchy
                {
                    ObjectId = obj.Id,
                    SubObjectId = subObject.Data.Id
                };
                response.Data = await _hierarchyRepository.Insert(newLine, token);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[AddNewSubObjectInObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteSubObjectFromObject(
            string? objectName,
            string subObjectName,
            CancellationToken token)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var obj = await _objectService.GetObjectByName(objectName, token);
                var subObject = await _subObjectService.GetSubObjectByName(subObjectName, token);

                if (obj == null || subObject.Data == null)
                {
                    return new BaseResponse<bool>
                    {
                        Description = "Object or SubObject not found",
                        StatusCode = StatusCode.ObjectNotFound
                    };
                }
                var hierarchies = await _hierarchyRepository.Select(token);

                var hierarchy = hierarchies.FirstOrDefault(x => 
                    x.ObjectId == obj.Id &&
                    x.SubObjectId == subObject.Data.Id);

                if (hierarchy == null)
                {
                    response.Description = "Link not found";
                    response.StatusCode = StatusCode.LinkNotFound;
                    return response;
                }
                response.Data = await _hierarchyRepository.Delete(hierarchy, token);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteSubObjectFromObject] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<int>> GetHierarchyId(
            int objectId,
            int subObjectId,
            CancellationToken token)
        {
            try
            {
                var hierarchies = await _hierarchyRepository.Select(token);
                var hierarchy = hierarchies.FirstOrDefault(x => 
                    x.ObjectId == objectId && 
                    x.SubObjectId == subObjectId);

                if (hierarchy == null)
                {
                    return new BaseResponse<int>
                    {
                        Description = "Link not found",
                        StatusCode = StatusCode.LinkNotFound
                    };
                }

                return new BaseResponse<int>
                {
                    Data = hierarchy.Id,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>()
                {
                    Description = $"[GetHierarchyId] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}