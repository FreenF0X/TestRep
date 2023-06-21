using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controllers
{
    public class NewController : Controller
    {
        [HttpGet]
        public string NewMethod()
        {
            return "New text";
        }
    }
}
