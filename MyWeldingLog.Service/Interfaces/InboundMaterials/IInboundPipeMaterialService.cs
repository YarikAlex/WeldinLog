using MyWeldingLog.Models.ActualMaterials;
using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Responses.Interfaces;

namespace MyWeldingLog.Service.Interfaces.InboundMaterials
{
    public interface IInboundPipeMaterialService
    {
        Task<IBaseResponse<ProjectPipeMaterial[]>> FindProjectPipesForActualPipe(InboundPipeMaterial model);

        Task<IBaseResponse<bool>> AddNewActualPipe(InboundPipeMaterial model);
    }
}