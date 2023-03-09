using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyWeldingLog.Models.Requests.Objects;
using MyWeldingLog.Service.Interfaces.Hierarchy;

namespace MyWeldingLog.Controllers
{
    [Route("hierarchy")]
    public class HierarchyController : Controller
    {
        private readonly IObjectService _objectService;
        private readonly JsonSerializerOptions _jsonOptions;

        public HierarchyController(IObjectService objectService)
        {
            _objectService = objectService;
            _jsonOptions = SetJsonOptions();
        }

        [HttpPost("add-object")]
        public async Task<IActionResult> CreateNewObject(CreateNewObjectRequest request)
        {
            var response = await _objectService.CreateNewObject(request);
            
            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpGet("get-objects")]
        public async Task<IActionResult> GetObjects()
        {
            var response = await _objectService.GetObjects();

            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpPost("delete-object")]
        public async Task<IActionResult> DeleteObject(DeleteObjectRequest request)
        {
            var response = await _objectService.DeleteObject(request);
            
            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpPost("rename-object")]
        public async Task<IActionResult> RenameObject(RenameObjectRequest request)
        {
            var response = await _objectService.RenameObject(request);

            return new JsonResult(response.Data, _jsonOptions);
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