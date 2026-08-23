using Microsoft.AspNetCore.Mvc;

namespace TXTC_Day2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
