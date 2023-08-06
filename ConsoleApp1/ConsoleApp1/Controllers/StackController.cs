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
        public string DeleteStack(int? id)
        {
            
            tempStackList.RemoveAt((int)id);
            return ("Стек номер: " + id + " удален.");
        }

        [HttpGet("count")]
        public string CountOfStacks()
        {
            return "Количество стеков: " + tempStackList.Count;
        }

        //[HttpPost("check")]
        //public string Check(RequestBody body)
        //{

        //    return ("Количество элементов в стеке: " + tempStackList[body.Number].Count);
        //}

        [HttpPost("push")]
        public string Push(int? id, RequestBody body)
        {
            tempStackList[(int)id].Push(body.Element);
            return "Добавлен элемент: " + body.Element;
        }

        [HttpGet("peek")]
        public string Peek(int? id)
        {
            try
            {
                return tempStackList[(int)id].Peek().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
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
