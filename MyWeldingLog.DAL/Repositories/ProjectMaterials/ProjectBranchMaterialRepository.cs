using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ProjectMaterials;

namespace MyWeldingLog.DAL.Repositories.ProjectMaterials
{
    public class ProjectBranchMaterialRepository : IProjectBranchMaterialRepository
    {
        public Task Insert(ProjectBranchMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectBranchMaterial[]> Select()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ProjectBranchMaterial entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProjectBranchMaterial entity)
        {
            throw new NotImplementedException();
        }
    }
}