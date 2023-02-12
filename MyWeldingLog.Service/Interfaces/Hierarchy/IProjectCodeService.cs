using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.Hierarchy
{
    public interface IProjectCodeService
    {
        Task<IBaseResponse<bool>> AddNewProjectCode(int hierarchyId, string projectCodeName);

        Task<IBaseResponse<bool>> DeleteProjectCode(int projectCodeId);
    }
}