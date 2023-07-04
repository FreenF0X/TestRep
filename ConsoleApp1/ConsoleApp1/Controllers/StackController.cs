using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
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
        Stack<string> stack = new Stack<string>();

        public StackController(Class2 class2)
        {

        }
        
        [HttpGet("Check")]
        public int Check()
        {
            
            return stack.Count;
        }

        [HttpPost("Push")]
        public string Push(RequestBody body)
        {
            stack.Push(body.Element);
            return "Добавлен элемент: "+ body.Element;
        }

        [HttpGet("Peek")]
        public string Peek()
        {
            return stack.Peek().ToString();
        }
        
        [HttpGet("Pop")]
        public string Pop()
        {
            return stack.Pop().ToString();
        }



    }

    public class RequestBody
    {
        public string Element { get; set; }
    }

}
