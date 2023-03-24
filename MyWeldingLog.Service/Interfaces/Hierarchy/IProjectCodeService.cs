using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IProjectCodeService
    {
        Task<bool> CreateNewProjectCode(
            int objectId,
            int subObjectId,
            string projectCodeName,
            CancellationToken token);

        Task<bool> DeleteProjectCode(int projectCodeId, CancellationToken token);
        
        Task<IEnumerable<ProjectCode>> GetProjectCodes(CancellationToken token);
        
        Task<ProjectCode> GetProjectCodeByName(
            string name,
            CancellationToken token);
        
        Task<bool> RenameProjectCode(
            int id,
            string newName,
            CancellationToken token);
    }
}