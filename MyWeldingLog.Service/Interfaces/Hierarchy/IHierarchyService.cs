using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IHierarchyService
    {
        Task<IBaseResponse<bool>> AddNewSubObjectInObject(
            int objectId,
            int subObjectId,
            CancellationToken token);

        Task<IBaseResponse<bool>> DeleteSubObjectFromObject(
            int objectId,
            int subObjectId,
            CancellationToken token);

        Task<IBaseResponse<int>> GetHierarchyId(
            int objectId,
            int subObjectId,
            CancellationToken token);
    }
}