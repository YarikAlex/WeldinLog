using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IProjectCodeService
    {
        Task<IBaseResponse<bool>> CreateNewProjectCode(
            int objectId,
            int subObjectId,
            string projectCodeName,
            CancellationToken token);

        Task<IBaseResponse<bool>> DeleteProjectCode(int projectCodeId, CancellationToken token);
        
        Task<IBaseResponse<IEnumerable<ProjectCode>>> GetProjectCodes(CancellationToken token);
        
        Task<IBaseResponse<ProjectCode>> GetProjectCodeByName(
            string name,
            CancellationToken token);
        
        Task<IBaseResponse<bool>> RenameProjectCode(
            int id,
            string newName,
            CancellationToken token);
    }
}