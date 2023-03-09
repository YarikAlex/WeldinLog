using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Responses.Interfaces;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IObjectService
    {
        Task<IBaseResponse<bool>> CreateNewObject(CreateNewObjectRequest request);
        
        Task<IBaseResponse<Object[]>> GetObjects();
        
        Task<IBaseResponse<bool>> DeleteObject(DeleteObjectRequest request);
        
        Task<IBaseResponse<bool>> RenameObject(RenameObjectRequest request);
    }
}