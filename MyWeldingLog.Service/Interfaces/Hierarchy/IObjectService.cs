using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Responses.Interfaces;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IObjectService
    {
        Task<bool> CreateNewObject(string objectName, CancellationToken token);
        
        Task<IEnumerable<Object>> GetObjects(CancellationToken token);
        
        Task<bool> DeleteObject(int objectId, CancellationToken token);
        
        Task<bool> RenameObject(
            int objectId,
            string newObjectName,
            CancellationToken token);

        Task<Object> GetObjectByName(
            string? objectName,
            CancellationToken token);
    }
}