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
                lines = lines.Where(line => 
                    line.ObjectId == objectId && 
                    line.SubObjectId == subObjectId)
                    .ToArray();

                if (lines.Length != 0)
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
    }
}