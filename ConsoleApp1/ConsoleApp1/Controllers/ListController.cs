using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
