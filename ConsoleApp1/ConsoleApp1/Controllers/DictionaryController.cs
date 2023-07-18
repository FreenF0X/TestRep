using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class DictionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
