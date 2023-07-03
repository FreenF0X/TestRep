using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("Stack")]
    public class StackController : ControllerBase
    {
        [HttpPost("Check")]
        public User Check(User user)
        {
            return user;
                   //$"Name: {name}  Age: {age}";
        }

    }

    public class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
