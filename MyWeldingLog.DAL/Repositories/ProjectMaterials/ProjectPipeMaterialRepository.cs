using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Repositories.ProjectMaterials
{
    public class ProjectPipeMaterialRepository : IProjectPipeMaterialRepository
    {
        public Task Insert(ProjectPipeMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectPipeMaterial[]> Select()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ProjectPipeMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProjectPipeMaterial entity)
        {
            throw new NotImplementedException();
        }
    }
}