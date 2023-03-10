using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Interfaces.ProjectMaterials
{
    public interface IProjectMaterialRepository : IBaseRepository<ProjectMaterial>
    {
        Task<bool> InsertProjectMaterials(ProjectMaterial[] entities, CancellationToken token);

        Task<bool> DeleteProjectMaterials(ProjectMaterial[] entities, CancellationToken token);

        Task<ProjectMaterial?> GetById(int id, CancellationToken token);
    }
}