using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello, controllers.";
        }
    }
}
