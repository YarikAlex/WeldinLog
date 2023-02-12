using MyWeldingLog.Models.Responses.Interfaces;
using Object = MyWeldingLog.Models.Hierarchy.Object;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IObjectService
    {
        Task<IBaseResponse<bool>> CreateNewObject(string name);
        
        Task<IBaseResponse<Object[]>> GetObjects();
        
        Task<IBaseResponse<bool>> DeleteObject(int id);
        
        Task<IBaseResponse<bool>> RenameObject(int id, string newName);
    }
}