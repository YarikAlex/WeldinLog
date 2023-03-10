using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Requests.ProjectCodes;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HierarchyController : Controller
    {
        private readonly IObjectService _objectService;
        private readonly IProjectCodeService _projectCodeService;
        private readonly JsonSerializerOptions _jsonOptions;

        public HierarchyController(
            IObjectService objectService,
            IProjectCodeService projectCodeService)
        {
            _objectService = objectService;
            _projectCodeService = projectCodeService;
            _jsonOptions = SetJsonOptions();
        }

        #region Objects
        [HttpPost("objects/add-object")]
        public async Task<IActionResult> CreateNewObject(CreateNewObjectRequest request)
        {
            var response = await _objectService.CreateNewObject(request);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpGet("objects/get-objects")]
        public async Task<IActionResult> GetObjects()
        {
            var response = await _objectService.GetObjects();

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("objects/delete-object")]
        public async Task<IActionResult> DeleteObject(DeleteObjectRequest request)
        {
            var response = await _objectService.DeleteObject(request);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("objects/rename-object")]
        public async Task<IActionResult> RenameObject(RenameObjectRequest request)
        {
            var response = await _objectService.RenameObject(request);

            return new JsonResult(response, _jsonOptions);
        }
        #endregion

        #region ProjectCodes
        [HttpPost("project-codes/create-new-project-code")]
        public async Task<IActionResult> CreateNewProjectCode(
            CreateNewProjectCodeRequest request)
        {
            var response = await _projectCodeService.CreateNewProjectCode(
                hierarchyId: request.HierarchyId,
                projectCodeName: request.ProjectCodeName);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/delete-project-code")]
        public async Task<IActionResult> DeleteProjectCode(
            DeleteProjectCodeRequest request)
        {
            var response = await _projectCodeService.DeleteProjectCode(request.ProjectCodeId);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/get-project-codes")]
        public async Task<IActionResult> GetProjectCodes()
        {
            var response = await _projectCodeService.GetProjectCodes();
            
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpPost("project-codes/get-project-code-by-name")]
        public async Task<IActionResult> GetProjectCodesByName(
            GetProjectCodeByNameRequest request)
        {
            var response = await _projectCodeService.GetProjectCodeByName(
                request.ProjectCodeName);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/rename-project-code")]
        public async Task<IActionResult> RenameProjectCode(
            RenameProjectCodeRequest request)
        {
            var response = await _projectCodeService.RenameProjectCode(
                request.ProjectCodeId,
                request.NewProjectCodeName);
            
            return new JsonResult(response, _jsonOptions);
        }
        #endregion

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