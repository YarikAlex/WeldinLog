using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyWeldingLog.Models.Requests.Hierarchy;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Requests.ProjectCodes;
using MyWeldingLog.Models.Requests.SubObjects;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HierarchyController : Controller
    {
        private readonly IObjectService _objectService;
        private readonly IProjectCodeService _projectCodeService;
        private readonly IHierarchyService _hierarchyService;
        private readonly ISubObjectService _subObjectService;
        private readonly JsonSerializerOptions _jsonOptions;

        public HierarchyController(
            IObjectService objectService,
            IProjectCodeService projectCodeService,
            IHierarchyService hierarchyService,
            ISubObjectService subObjectService)
        {
            _objectService = objectService;
            _projectCodeService = projectCodeService;
            _hierarchyService = hierarchyService;
            _subObjectService = subObjectService;
            _jsonOptions = SetJsonOptions();
        }

        #region Objects
        [HttpPost("objects/add-object")]
        public async Task<IActionResult> CreateNewObject(
            CreateNewObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.CreateNewObject(request, token);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("objects/get-objects")]
        public async Task<IActionResult> GetObjects(CancellationToken token)
        {
            var response = await _objectService.GetObjects(token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("objects/delete-object")]
        public async Task<IActionResult> DeleteObject(
            DeleteObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.DeleteObject(request, token);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("objects/rename-object")]
        public async Task<IActionResult> RenameObject(
            RenameObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.RenameObject(request, token);

            return new JsonResult(response, _jsonOptions);
        }
        #endregion

        #region SubObjects
        [HttpPost("sub-object/create-new-sub-object")]
        public async Task<IActionResult> CreateNewSubObject(
            CreateNewSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.CreateNewSubObject(
                request.SubObjectName,
                token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("sub-object/get-sub-object-by-name")]
        public async Task<IActionResult> GetSubObjectByName(
            GetSubObjectByNameRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.GetSubObjectByName(
                request.SubObjectName,
                token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("sub-object/get-sub-objects")]
        public async Task<IActionResult> GetSubObjects(CancellationToken token)
        {
            var response = await _subObjectService.GetSubObjects(token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("sub-object/delete-sub-object")]
        public async Task<IActionResult> DeleteSubObject(
            DeleteSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.DeleteSubObject(
                request.SubObjectId,
                token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("sub-object/rename-sub-object")]
        public async Task<IActionResult> RenameSubObject(
            RenameSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.RenameSubObject(
                request.SubObjectId,
                request.NewSubObjectName,
                token);

            return new JsonResult(response, _jsonOptions);
        }
        #endregion

        #region Hierarchy
        [HttpPost("hierarchy/connect-sub-object-to-object")]
        public async Task<IActionResult> ConnectSubObjectToObject(
            ConnectSubObjectAndObjectRequest request,
            CancellationToken token)
        {
            var response = await _hierarchyService.AddNewSubObjectInObject(
                request.ObjectName,
                request.SubObjectName,
                token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("hierarchy/disconnect-sub-object-from-object")]
        public async Task<IActionResult> DisconnectSubObjectFromObject(
            DisconnectSubObjectFromObjectRequest request,
            CancellationToken token)
        {
            var response = await _hierarchyService.DeleteSubObjectFromObject(
                request.ObjectName,
                request.SubObjectName,
                token);

            return new JsonResult(response, _jsonOptions);
        }
        #endregion

        #region ProjectCodes
        [HttpPost("project-codes/create-new-project-code")]
        public async Task<IActionResult> CreateNewProjectCode(
            CreateNewProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.CreateNewProjectCode(
                objectId: request.ObjectId,
                subObjectId: request.SubObjectId,
                projectCodeName: request.ProjectCodeName,
                token: token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/delete-project-code")]
        public async Task<IActionResult> DeleteProjectCode(
            DeleteProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.DeleteProjectCode(
                request.ProjectCodeId,
                token);

            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/get-project-codes")]
        public async Task<IActionResult> GetProjectCodes(CancellationToken token)
        {
            var response = await _projectCodeService.GetProjectCodes(token);
            
            return new JsonResult(response, _jsonOptions);
        }
        
        [HttpPost("project-codes/get-project-code-by-name")]
        public async Task<IActionResult> GetProjectCodesByName(
            GetProjectCodeByNameRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.GetProjectCodeByName(
                request.ProjectCodeName,
                token);
            
            return new JsonResult(response, _jsonOptions);
        }

        [HttpPost("project-codes/rename-project-code")]
        public async Task<IActionResult> RenameProjectCode(
            RenameProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.RenameProjectCode(
                request.ProjectCodeId,
                request.NewProjectCodeName,
                token);
            
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