using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Interfaces.ProjectMaterials
{
    public interface IProjectBranchMaterialRepository : IBaseRepository<ProjectBranchMaterial>
    {
        Task<ProjectBranchMaterial?> Get(int id);
    }
}