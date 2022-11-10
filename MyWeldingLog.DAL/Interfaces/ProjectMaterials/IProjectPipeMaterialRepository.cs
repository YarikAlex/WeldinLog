using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Interfaces.ProjectMaterials
{
    public interface IProjectPipeMaterialRepository : IBaseRepository<ProjectPipeMaterial>
    {
        Task<ProjectPipeMaterial?> Get(int id);
    }
}