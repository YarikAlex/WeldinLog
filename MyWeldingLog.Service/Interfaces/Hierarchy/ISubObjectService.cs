using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface ISubObjectService
    {
        Task<IBaseResponse<bool>> CreateNewSubObject(string name, CancellationToken token);
        Task<IBaseResponse<SubObject>> GetSubObjectByName(string name, CancellationToken token);
        Task<IBaseResponse<IEnumerable<SubObject>>> GetSubObjects(CancellationToken token);
        Task<IBaseResponse<bool>> DeleteSubObject(int id, CancellationToken token);
        Task<IBaseResponse<bool>> RenameSubObject(int id, string newName, CancellationToken token);
    }
}