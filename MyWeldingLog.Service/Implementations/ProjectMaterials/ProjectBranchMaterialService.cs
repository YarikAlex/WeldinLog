using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Interfaces.ProjectMaterials;

namespace MyWeldingLog.Service.Implementations.ProjectMaterials
{
    public class ProjectBranchMaterialService : IProjectBranchMaterialService
    {
        private readonly IProjectBranchMaterialRepository _projectBranchMaterialRepository;

        public ProjectBranchMaterialService(IProjectBranchMaterialRepository projectBranchMaterialRepository)
        {
            _projectBranchMaterialRepository = projectBranchMaterialRepository;
        }

        public async Task<IBaseResponse<bool>> AddNewProjectBranch(ProjectBranchMaterial model)
        {
            var response = new BaseResponse<bool>();
            ///TODO: Добавить проверку модели на null
            try
            {
                response.Data = await _projectBranchMaterialRepository.Insert(model);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[AddNewProjectBranch] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranchByDiameter(ushort diameter)
        {
            var response = new BaseResponse<ProjectBranchMaterial[]>();
            try
            {
                var projectBranches = await _projectBranchMaterialRepository.Select();
                projectBranches = projectBranches
                    .Where(branch => branch.Diameter == diameter && branch.IsDeleted == false)
                    .ToArray();
                
                if (projectBranches.Length == 0)
                {
                    response.Description = "Branch not found";
                    response.StatusCode = StatusCode.BranchNotFound;
                    return response;
                }

                response.Data = projectBranches;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectBranchMaterial[]>()
                {
                    Description = $"[GetProjectBranchByDiameter] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranchByFactory(string factory)
        {
            var response = new BaseResponse<ProjectBranchMaterial[]>();
            try
            {
                var projectBranches = await _projectBranchMaterialRepository.Select();
                projectBranches = projectBranches
                    .Where(branch => branch.Factory == factory && branch.IsDeleted == false)
                    .ToArray();
                
                if (projectBranches.Length == 0)
                {
                    response.Description = "Branch not found";
                    response.StatusCode = StatusCode.BranchNotFound;
                    return response;
                }

                response.Data = projectBranches;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectBranchMaterial[]>()
                {
                    Description = $"[GetProjectBranchByFactory] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectBranchMaterial[]>> GetProjectBranches()
        {
            var response = new BaseResponse<ProjectBranchMaterial[]>();
            try
            {
                var projectBranches = await _projectBranchMaterialRepository.Select();
                projectBranches = projectBranches
                    .Where(branch => branch.IsDeleted == false)
                    .ToArray();

                if (projectBranches.Length == 0)
                {
                    response.Description = "Branch not found";
                    response.StatusCode = StatusCode.BranchNotFound;
                    return response;
                }

                response.Data = projectBranches;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectBranchMaterial[]>()
                {
                    Description = $"[GetProjectBranches] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteProjectBranch(int projectBranchId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var deletingBranch = await _projectBranchMaterialRepository.Get(projectBranchId);
                if (deletingBranch == null)
                {
                    response.Description = "Branch not found";
                    response.StatusCode = StatusCode.BranchNotFound;
                    return response;
                }

                deletingBranch.IsDeleted = true;
                response.Data = await _projectBranchMaterialRepository.Delete(deletingBranch);
                
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteProjectBranch] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}