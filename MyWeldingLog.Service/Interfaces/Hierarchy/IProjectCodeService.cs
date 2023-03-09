using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IProjectCodeService
    {
        Task<IBaseResponse<bool>> CreateNewProjectCode(int hierarchyId, string projectCodeName);

        Task<IBaseResponse<bool>> DeleteProjectCode(int projectCodeId);
        
        Task<IBaseResponse<IEnumerable<ProjectCode>>> GetProjectCodes();
        
        Task<IBaseResponse<ProjectCode>> GetProjectCodeByName(string name);
        
        Task<IBaseResponse<bool>> RenameProjectCode(int id, string newName);
    }
}