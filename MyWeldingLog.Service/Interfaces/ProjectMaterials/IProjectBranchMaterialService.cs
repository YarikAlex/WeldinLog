using MyWeldingLog.Models.ProjectMaterials;

using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.ProjectMaterials
{
    public interface IProjectBranchMaterialService
    {
        Task<IBaseResponse<bool>> AddNewProjectBranch(ProjectBranchMaterial model);
        
        Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranchByDiameter(ushort diameter);
        
        Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranchByFactory(string factory);
        
        Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranches();
        
        Task<IBaseResponse<bool>> DeleteProjectBranch(int projectBranchId);
    }
}