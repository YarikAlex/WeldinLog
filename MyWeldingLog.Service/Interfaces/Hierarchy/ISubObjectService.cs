using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface ISubObjectService
    {
        Task<IBaseResponse<bool>> CreateNewSubObject(string name);
        Task<IBaseResponse<SubObject>> GetSubObjectByName(string name);
        Task<IBaseResponse<SubObject[]>> GetSubObjects();
        Task<IBaseResponse<bool>> DeleteSubObject(int id);
        Task<IBaseResponse<bool>> RenameSubObject(int id, string newName);
    }
}