using MyWeldingLog.DAL.Interfaces;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IHierarchyService
    {
        Task<IBaseResponse<bool>> AddNewSubObjectInObject(int objectId, int subObjectId);
    }
}