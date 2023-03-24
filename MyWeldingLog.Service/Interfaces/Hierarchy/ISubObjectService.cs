using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface ISubObjectService
    {
        Task<bool> CreateNewSubObject(string name, CancellationToken token);
        Task<SubObject> GetSubObjectByName(string name, CancellationToken token);
        Task<IEnumerable<SubObject>> GetSubObjects(CancellationToken token);
        Task<bool> DeleteSubObject(int id, CancellationToken token);
        Task<bool> RenameSubObject(int id, string newName, CancellationToken token);
    }
}