using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello, controllers.";
        }
        [HttpGet]
        public string SomeMethod()
        {
            return "Some text";
        }
    }
}
