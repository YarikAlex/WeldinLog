using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Interfaces.ProjectMaterials
{
    public interface IProjectMaterialRepository : IBaseRepository<ProjectMaterial>
    {
        Task<bool> InsertProjectMaterials(ProjectMaterial[] entities);

        Task<bool> DeleteProjectMaterials(ProjectMaterial[] entities);
    }
}