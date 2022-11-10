using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.ProjectMaterials
{
    public interface IProjectPipeMaterialService
    {
        Task<IBaseResponse<bool>> AddNewProjectPipe(ProjectPipeMaterial model);
        
        Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipeByDiameter(ushort diameter);
        
        Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipeByFactory(string factory);
        
        Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipes();
        
        Task<IBaseResponse<bool>> DeleteProjectPipe(int projectPipeId);
    }
}