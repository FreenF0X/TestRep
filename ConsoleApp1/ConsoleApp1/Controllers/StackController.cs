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

        [HttpDelete("{id}")]
        public ResponseBody DeleteStack(int id)
        {

            tempStackList.RemoveAt(id);
            return new ResponseBody { Response = "Стек номер: " + id + " удален." };
        }

        [HttpGet("count")]
        public ResponseBody CountOfStacks()
        {
            return new ResponseBody { Response = "Количество стеков: " + tempStackList.Count };
        }

        [HttpGet("check/{id}")]
        public ResponseBody Check(int id)
        {

            return new ResponseBody { Response = ("Количество элементов в стеке: " + tempStackList[id].Count) };
        }

        [HttpPost("push/{id}")]
        public ResponseBody Push(int id, RequestBody body)
        {
            tempStackList[id].Push(body.Element);
            return new ResponseBody { Response = "Добавлен элемент: " + body.Element };
        }

        [HttpGet("peek/{id}")]
        public ResponseBody Peek(int id)
        {
            try
            {
                return new ResponseBody { Response = tempStackList[id].Peek().ToString() };
            }
            catch (Exception ex)
            {
                return new ResponseBody { Response = ex.Message };
            }
        }

        [HttpGet("pop/{id}")]
        public ResponseBody Pop(int id)
        {
            try
            {
                return new ResponseBody { Response = tempStackList[id].Pop().ToString() };
            }
            catch (Exception ex)
            {
                return new ResponseBody { Response = ex.Message };
            }
        }


    }

}
