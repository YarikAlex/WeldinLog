using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Responses.Interfaces;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IObjectService
    {
        Task<IBaseResponse<bool>> CreateNewObject(CreateNewObjectRequest request, CancellationToken token);
        
        Task<IBaseResponse<Object[]>> GetObjects(CancellationToken token);
        
        Task<IBaseResponse<bool>> DeleteObject(DeleteObjectRequest request, CancellationToken token);
        
        Task<IBaseResponse<bool>> RenameObject(RenameObjectRequest request, CancellationToken token);
    }
}