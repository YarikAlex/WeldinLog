using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IHierarchyService
    {
        Task<bool> AddNewSubObjectInObject(
            string objectName,
            string subObjectName,
            CancellationToken token);

        Task<bool> DeleteSubObjectFromObject(
            string objectName,
            string subObjectName,
            CancellationToken token);

        Task<int> GetHierarchyId(
            int objectId,
            int subObjectId,
            CancellationToken token);
    }
}