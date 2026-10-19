using Microsoft.AspNetCore.Mvc;

namespace Txtc_Demo_lesson3.Controllers
{
    /// <summary>
    /// Name: TXTC About
    /// Author: Tuấn Cường
    /// </summary>
    public class TxtcAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Trần Xuân Tuấn Cường";
            ViewData["Job"] = "PT Gym";
            TempData["Address"] = "Hà Nội";
            return View();
        }
    }
}
