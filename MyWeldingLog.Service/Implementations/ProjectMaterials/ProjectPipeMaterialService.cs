using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Interfaces.ProjectMaterials;

namespace MyWeldingLog.Service.Implementations.ProjectMaterials
{
    public class ProjectPipeMaterialService : IProjectPipeMaterialService
    {
        private readonly IProjectPipeMaterialRepository _projectPipeMaterialRepository;

        public ProjectPipeMaterialService(IProjectPipeMaterialRepository projectPipeMaterialRepository)
        {
            _projectPipeMaterialRepository = projectPipeMaterialRepository;
        }

        public async Task<IBaseResponse<bool>> AddNewProjectPipe(ProjectPipeMaterial model)
        {
            var response = new BaseResponse<bool>();
            ///TODO: Добавить проверку модели на null
            try
            {
                response.Data = await _projectPipeMaterialRepository.Insert(model);
                response.StatusCode = StatusCode.Ok;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[AddNewProjectPipe] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipeByDiameter(ushort diameter)
        {
            var response = new BaseResponse<ProjectPipeMaterial[]>();
            try
            {
                var projectPipes = await _projectPipeMaterialRepository.Select();
                projectPipes = projectPipes
                    .Where(pipe => pipe.Diameter == diameter && pipe.IsDeleted == false)
                    .ToArray();
                if (projectPipes.Length == 0)
                {
                    response.Description = "Pipe not found";
                    response.StatusCode = StatusCode.PipeNotFound;
                    return response;
                }

                response.Data = projectPipes;
                response.StatusCode = StatusCode.Ok;
                
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectPipeMaterial[]>
                {
                    Description = $"[GetPipeMaterialsByDiameter] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipeByFactory(string factory)
        {
            var response = new BaseResponse<ProjectPipeMaterial[]>();
            try
            {
                var projectPipes = await _projectPipeMaterialRepository.Select();
                projectPipes = projectPipes
                    .Where(pipe => pipe.Factory == factory && pipe.IsDeleted == false)
                    .ToArray();

                if (projectPipes.Length == 0)
                {
                    response.Description = "Pipe not found";
                    response.StatusCode = StatusCode.PipeNotFound;
                    return response;
                }

                response.Data = projectPipes;
                response.StatusCode = StatusCode.Ok;
                
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectPipeMaterial[]>
                {
                    Description = $"[GetPipeMaterialsByFactory] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProjectPipeMaterial[]>> GetProjectPipes()
        {
            var response = new BaseResponse<ProjectPipeMaterial[]>();
            try
            {
                var projectPipes =  await _projectPipeMaterialRepository.Select();
                projectPipes = projectPipes
                    .Where(pipe => pipe.IsDeleted == false)
                    .ToArray();

                if (projectPipes.Length == 0)
                {
                    response.Description = "Pipe not found";
                    response.StatusCode = StatusCode.PipeNotFound;
                    return response;
                }

                response.Data = projectPipes;
                response.StatusCode = StatusCode.Ok;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectPipeMaterial[]>
                {
                    Description = $"[GetPipeMaterials] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteProjectPipe(int projectPipeId)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var deletingPipe = await _projectPipeMaterialRepository.Get(projectPipeId);
                
                if (deletingPipe == null)
                {
                    response.Description = "Pipe not found";
                    response.StatusCode = StatusCode.PipeNotFound;
                    return response;
                }

                deletingPipe.IsDeleted = true;
                response.Data = await _projectPipeMaterialRepository.Delete(deletingPipe);
                response.StatusCode = StatusCode.Ok;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[GetPipeMaterials] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}