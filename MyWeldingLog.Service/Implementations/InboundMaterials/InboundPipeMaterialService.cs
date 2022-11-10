using MyWeldingLog.DAL.Interfaces.Hierarchy;
using MyWeldingLog.DAL.Interfaces.InboundMaterials;
using MyWeldingLog.DAL.Interfaces.ProjectMaterials;
using MyWeldingLog.Models.ActualMaterials;
using MyWeldingLog.Models.Enums;
using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Responses;
using MyWeldingLog.Models.Responses.Interfaces;
using MyWeldingLog.Service.Interfaces.InboundMaterials;

namespace MyWeldingLog.Service.Implementations.InboundMaterials
{
    public class InboundPipeMaterialService : IInboundPipeMaterialService
    {
        private readonly IInboundPipeMaterialRepository _inboundPipeMaterialRepository;
        private readonly IProjectPipeMaterialRepository _projectPipeMaterialRepository;
        private readonly IProjectCodeRepository _projectCodeRepository;

        public InboundPipeMaterialService(IInboundPipeMaterialRepository inboundPipeMaterialRepository,
            IProjectPipeMaterialRepository projectPipeMaterialRepository,
            IProjectCodeRepository projectCodeRepository)
        {
            _inboundPipeMaterialRepository = inboundPipeMaterialRepository;
            _projectPipeMaterialRepository = projectPipeMaterialRepository;
            _projectCodeRepository = projectCodeRepository;
        }

        public async Task<IBaseResponse<ProjectPipeMaterial[]>> FindProjectPipesForActualPipe(InboundPipeMaterial model)
        {
            var response = new BaseResponse<ProjectPipeMaterial[]>();
            try
            {
                var projectCodes = await _projectCodeRepository.Select();
                var projectCodesIds = projectCodes.Where(pc => pc.ObjectId == model.ObjectId)
                    .Select(pc => pc.Id)
                    .ToArray();
                
                var projectPipes = await _projectPipeMaterialRepository.Select();
                var projectPipesCodeIds = projectPipes
                    .Where(pp => pp.Diameter == model.Diameter && pp.Wall == model.Wall)
                    .Select(pp => pp.ProjectCodeId)
                    .ToArray().Distinct();
                
                var result = projectPipesCodeIds.Intersect(projectCodesIds).ToArray();
                
                var resultPipes = (from pipe in projectPipes 
                    from iter in result 
                    where pipe.ProjectCodeId == iter select pipe)
                    .ToArray();

                response.Data = resultPipes;
                response.StatusCode = StatusCode.Ok;
                
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProjectPipeMaterial[]>
                {
                    Description = $"[FindProjectPipeForActualPipe] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> AddNewActualPipe(InboundPipeMaterial model)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.Data = await _inboundPipeMaterialRepository.Insert(model);
                response.StatusCode = StatusCode.Ok;

                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[AddNewActualPipe] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}