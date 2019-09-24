using Microsoft.AspNetCore.Mvc;

namespace LightpointTestTask.WEB.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Задание";
            return View();
        }
    }
}
