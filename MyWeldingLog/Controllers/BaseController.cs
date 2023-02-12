using Microsoft.AspNetCore.Mvc;

namespace MyWeldingLog.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public HomeController()
        {
       
        }

        public async Task Index()
        {
            await Response.WriteAsync("HomeController - Index");
        }
    }
}