using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("stacks")]
    public class StackController : ControllerBase
    {
        List<Stack<String>> tempStackList;

        public StackController(List<Stack<String>> staсkList)
        {
            tempStackList = staсkList;
        }

        [HttpPost]
        public ResponseBody CreateNewStack()
        {
            tempStackList.Add(new Stack<string>());
            return new ResponseBody { Response = "Новый стек создан." };
        }

        [HttpDelete]
        public ResponseBody DeleteStack(int? id)
        {
            
            tempStackList.RemoveAt((int)id);
            return new ResponseBody { Response = "Стек номер: " + id + " удален." };
        }

        [HttpGet("count")]
        public ResponseBody CountOfStacks()
        {
            return  new ResponseBody { Response = "Количество стеков: " + tempStackList.Count };
        }

        [HttpGet("check")]
        public ResponseBody Check(int? id)
        {

            return new ResponseBody { Response = ("Количество элементов в стеке: " + tempStackList[(int)id].Count) };
        }

        [HttpPost("push")]
        public ResponseBody Push(int? id, RequestBody body)
        {
            tempStackList[(int)id].Push(body.Element);
            return new ResponseBody { Response = "Добавлен элемент: " + body.Element };
        }

        [HttpGet("peek")]
        public ResponseBody Peek(int? id)
        {
            try
            {
                return new ResponseBody {Response = tempStackList[(int)id].Peek().ToString() };
            }
            catch(Exception ex)
            {
                return new ResponseBody { Response = ex.Message };
            }
        }

        [HttpGet("pop")]
        public string Pop(int? id)
        {
            try
            {
                return tempStackList[(int)id].Pop().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }

}
