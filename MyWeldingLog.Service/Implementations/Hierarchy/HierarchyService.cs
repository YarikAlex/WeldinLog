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

        public HierarchyService(IHierarchyRepository hierarchyRepository)
        {
            _hierarchyRepository = hierarchyRepository;
        }

        public async Task<IBaseResponse<bool>> AddNewSubObjectInObject(int objectId, int subObjectId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var lines = await _hierarchyRepository.Select();
                var subObjectIds = lines
                    .Where(line => line.ObjectId == objectId)
                    .Select(x => x.SubObjectId)
                    .ToArray();

                if (!subObjectIds.Contains(subObjectId))
                {
                    response.Description = "Link already exists";
                    response.StatusCode = StatusCode.LinkAlreadyExist;
                    return response;
                }
                
                var newLine = new Models.Hierarchy.Hierarchy
                {
                    ObjectId = objectId,
                    SubObjectId = subObjectId
                };
                response.Data = await _hierarchyRepository.Insert(newLine);
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

        public async Task<IBaseResponse<bool>> DeleteSubObjectFromObject(int objectId, int subObjectId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var lines = await _hierarchyRepository.Select();

                var line = lines.FirstOrDefault(x => 
                    x.ObjectId == objectId &&
                    x.SubObjectId == subObjectId);

                if (line == null)
                {
                    response.Description = "Link not found";
                    response.StatusCode = StatusCode.LinkNotFound;
                    return response;
                }
                response.Data = await _hierarchyRepository.Delete(line);
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
    }
}