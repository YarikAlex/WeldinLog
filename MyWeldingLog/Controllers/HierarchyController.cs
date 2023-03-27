using Microsoft.AspNetCore.Mvc;
using MyWeldingLog.Models.Hierarchy;
using MyWeldingLog.Models.Requests.Hierarchy;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Models.Requests.ProjectCodes;
using MyWeldingLog.Models.Requests.SubObjects;
using MyWeldingLog.Service.Exceptions.BaseException.Elements;
using MyWeldingLog.Service.Interfaces.Hierarchy;
using Object = System.Object;

namespace MyWeldingLog.Controllers
{
    [Route("hierarchy")]
    [ApiController]
    public class HierarchyController : Controller
    {
        private readonly IObjectService _objectService;
        private readonly IProjectCodeService _projectCodeService;
        private readonly IHierarchyService _hierarchyService;
        private readonly ISubObjectService _subObjectService;

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
        }

        #region Objects
        [HttpPost("objects/create")]
        public async Task<ActionResult<Result<bool>>> CreateNewObject(
            CreateNewObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.CreateNewObject(request.ObjectName, token);
            
            return Ok(response);
        }

        [HttpPost("objects/get-all")]
        public async Task<ActionResult<Result<IEnumerable<Object>>>> GetObjects(CancellationToken token)
        {
            var response = await _objectService.GetObjects(token);

            return Ok(response);
        }

        [HttpPost("objects/delete")]
        public async Task<ActionResult<Result<bool>>> DeleteObject(
            DeleteObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.DeleteObject(request.ObjectId, token);

            return Ok(response);
        }

        [HttpPost("objects/rename")]
        public async Task<ActionResult<Result<bool>>> RenameObject(
            RenameObjectRequest request,
            CancellationToken token)
        {
            var response = await _objectService.RenameObject(
                request.ObjectId,
                request.NewObjectName,
                token);

            return Ok(response);
        }
        #endregion

        #region SubObjects
        [HttpPost("sub-objects/create")]
        public async Task<ActionResult<Result<bool>>> CreateNewSubObject(
            CreateNewSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.CreateNewSubObject(
                request.SubObjectName,
                token);

            return Ok(response);
        }

        [HttpPost("sub-objects/get-by-name")]
        public async Task<ActionResult<Result<SubObject>>> GetSubObjectByName(
            GetSubObjectByNameRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.GetSubObjectByName(
                request.SubObjectName,
                token);

            return Ok(response);
        }

        [HttpPost("sub-objects/get-all")]
        public async Task<ActionResult<Result<IEnumerable<SubObject>>>> GetSubObjects(CancellationToken token)
        {
            var response = await _subObjectService.GetSubObjects(token);

            return Ok(response);
        }

        [HttpPost("sub-objects/delete")]
        public async Task<ActionResult<Result<bool>>> DeleteSubObject(
            DeleteSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.DeleteSubObject(
                request.SubObjectId,
                token);

            return Ok(response);
        }

        [HttpPost("sub-object/rename")]
        public async Task<ActionResult<Result<bool>>> RenameSubObject(
            RenameSubObjectRequest request,
            CancellationToken token)
        {
            var response = await _subObjectService.RenameSubObject(
                request.SubObjectId,
                request.NewSubObjectName,
                token);

            return Ok(response);
        }
        #endregion

        #region Hierarchy
        [HttpPost("hierarchy/connect")]
        public async Task<ActionResult<Result<bool>>> ConnectSubObjectToObject(
            ConnectSubObjectAndObjectRequest request,
            CancellationToken token)
        {
            var response = await _hierarchyService.AddNewSubObjectInObject(
                request.ObjectName,
                request.SubObjectName,
                token);

            return Ok(response);
        }

        [HttpPost("hierarchy/disconnect")]
        public async Task<ActionResult<Result<bool>>> DisconnectSubObjectFromObject(
            DisconnectSubObjectFromObjectRequest request,
            CancellationToken token)
        {
            var response = await _hierarchyService.DeleteSubObjectFromObject(
                request.ObjectName,
                request.SubObjectName,
                token);

            return Ok(response);
        }
        #endregion

        #region ProjectCodes
        [HttpPost("project-codes/create")]
        public async Task<ActionResult<Result<bool>>> CreateNewProjectCode(
            CreateNewProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.CreateNewProjectCode(
                objectId: request.ObjectId,
                subObjectId: request.SubObjectId,
                projectCodeName: request.ProjectCodeName,
                token: token);

            return Ok(response);
        }

        [HttpPost("project-codes/delete")]
        public async Task<ActionResult<Result<bool>>> DeleteProjectCode(
            DeleteProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.DeleteProjectCode(
                request.ProjectCodeId,
                token);

            return Ok(response);
        }

        [HttpPost("project-codes/get-all")]
        public async Task<ActionResult<Result<IEnumerable<ProjectCode>>>> GetProjectCodes(CancellationToken token)
        {
            var response = await _projectCodeService.GetProjectCodes(token);
            
            return Ok(response);
        }
        
        [HttpPost("project-codes/get-by-name")]
        public async Task<ActionResult<Result<ProjectCode>>> GetProjectCodesByName(
            GetProjectCodeByNameRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.GetProjectCodeByName(
                request.ProjectCodeName,
                token);
            
            return Ok(response);
        }

        [HttpPost("project-codes/rename")]
        public async Task<ActionResult<Result<bool>>> RenameProjectCode(
            RenameProjectCodeRequest request,
            CancellationToken token)
        {
            var response = await _projectCodeService.RenameProjectCode(
                request.ProjectCodeId,
                request.NewProjectCodeName,
                token);
            
            return Ok(response);
        }
        #endregion
    }
}