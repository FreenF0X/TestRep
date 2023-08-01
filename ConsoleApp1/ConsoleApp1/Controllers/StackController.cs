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
        public string CreateNewStack()
        {
            tempStackList.Add(new Stack<string>());
            return "Новый стек создан.";
        }

        [HttpDelete]
        public string DeleteStack(int id)
        {
            tempStackList.RemoveAt(body.Number);
            return ("Стек номер: " + body.Number + " удален.");
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
        public string Push(RequestBody body)
        {
            tempStackList[body.Number].Push(body.Element);
            return "Добавлен элемент: " + body.Element;
        }

        [HttpGet("peek")]
        public string Peek(RequestBody body)
        {
            try
            {
                return tempStackList[body.Number].Peek().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("pop")]
        public string Pop(RequestBody body)
        {
            try
            {
                return tempStackList[body.Number].Pop().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }

}
