using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyWeldingLog.Models.ProjectMaterials;
using MyWeldingLog.Models.Requests;
using MyWeldingLog.Service.Interfaces.ProjectMaterials;

namespace MyWeldingLog.Controllers
{
    [Route("projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectPipeMaterialService _projectPipeMaterialService;
        private readonly IProjectBranchMaterialService _projectBranchMaterialService;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProjectController(IProjectPipeMaterialService projectPipeMaterialService,
            IProjectBranchMaterialService projectBranchMaterialService)
        {
            _jsonOptions = SetJsonOptions();
            _projectPipeMaterialService = projectPipeMaterialService;
            _projectBranchMaterialService = projectBranchMaterialService;
        }

        [HttpPost("add-new-project-pipe")]
        public async Task<IActionResult> AddNewProjectPipe(CreateNewProjectPipeRequest request)
        {
            var newPipe = new ProjectPipeMaterial
            {
                ProjectCodeId = request.ProjectCodeId,
                Diameter = request.Diameter,
                Wall = request.Wall,
                Steel = request.Steel,
                TechnicalConditions = request.TechnicalConditions,
                Factory = request.Factory,
                IsIsolated = request.IsIsolated,
                IsDeleted = false,
                Quantity = request.Quantity
            };

            var response = await _projectPipeMaterialService.AddNewProjectPipe(newPipe);
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("add-new-project-branch")]
        public async Task<IActionResult> AddNewProjectBranch(CreateNewProjectBranchRequest request)
        {
            var newBranch = new ProjectBranchMaterial
            {
                ProjectCodeId = request.ProjectCodeId,
                Diameter = request.Diameter,
                Wall = request.Wall,
                Angle = request.Angle,
                BranchType = request.BranchType,
                Strength = request.Steel,
                TechnicalConditions = request.TechnicalConditions,
                Factory = request.Factory,
                IsIsolated = request.IsIsolated,
                IsDeleted = false,
                Quantity = request.Quantity
            };

            var response = await _projectBranchMaterialService.AddNewProjectBranch(newBranch);
            return new JsonResult(response, _jsonOptions);
        }

        [HttpGet("get-project-pipes-by-diameter")]
        public async Task<IActionResult> GetProjectPipesByDiameter(ushort diameter)
        {
            var response = await _projectPipeMaterialService.GetProjectPipeByDiameter(diameter);
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpGet("get-project-branches-by-diameter")]
        public async Task<IActionResult> GetProjectBranchesByDiameter(ushort diameter)
        {
            var response = await _projectBranchMaterialService.GetProjectBranchByDiameter(diameter);
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpGet("get-project-pipes-by-factory")]
        public async Task<IActionResult> GetProjectPipesByFactory(string factory)
        {
            var response = await _projectPipeMaterialService.GetProjectPipeByFactory(factory);
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpGet("get-project-branches-by-factory")]
        public async Task<IActionResult> GetProjectBranchesByFactory(string factory)
        {
            var response = await _projectBranchMaterialService.GetProjectBranchByFactory(factory);
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpGet("get-project-pipes")]
        public async Task<IActionResult> GetProjectPipes()
        {
            var response = await _projectPipeMaterialService.GetProjectPipes();
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpGet("get-project-branches")]
        public async Task<IActionResult> GetProjectBranches()
        {
            var response = await _projectBranchMaterialService.GetProjectBranches();
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("delete-project-pipe")]
        public async Task<IActionResult> DeleteProjectPipe(DeletePipeMaterialRequest request)
        {
            var response = await _projectPipeMaterialService.DeleteProjectPipe(request.ProjectPipeId);
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpPost("delete-project-branch")]
        public async Task<IActionResult> DeleteProjectBranch(DeleteBranchMaterialRequest request)
        {
            var response = await _projectPipeMaterialService.DeleteProjectPipe(request.ProjectBranchId);
            return new JsonResult(response, _jsonOptions);
        }

        ///TODO: Перенести метод в отдельный файл настроек
        private JsonSerializerOptions SetJsonOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }
    }
}