using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddNewObject(string name)
        {
            var response = await _objectService.CreateNewObject(name);
            
            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpGet("get-objects")]
        public async Task<IActionResult> GetObjects()
        {
            var response = await _objectService.GetObjects();

            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpPost("delete-object")]
        public async Task<IActionResult> DeleteObject(int id)
        {
            var response = await _objectService.DeleteObject(id);
            
            return new JsonResult(response.Data, _jsonOptions);
        }

        [HttpPost("rename-object")]
        public async Task<IActionResult> RenameObject(int id, string newName)
        {
            var response = await _objectService.RenameObject(id, newName);

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