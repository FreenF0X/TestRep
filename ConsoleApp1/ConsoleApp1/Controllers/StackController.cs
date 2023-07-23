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
    [Route("Stack")]
    public class StackController : ControllerBase
    {
        List<Stack<String>> tempStackList;

        public StackController(List<Stack<String>> StaсkList)
        {
            tempStackList = StaсkList;
        }

        [HttpGet("CreateNewStack")]
        public string CreateNewStack()
        {
            tempStackList.Add(new Stack<string>());
            return "Новый стек создан.";
        }

        [HttpPost("DeleteStack")]
        public string DeleteStack(RequestBody body)
        {
            tempStackList.RemoveAt(body.Number);
            return ("Стек номер: " + body.Number + " удален.");
        }

        [HttpGet("CountOfStacks")]
        public string CountOfStacks()
        {
            return "Количество стеков: " + tempStackList.Count;
        }

        [HttpPost("Check")]
        public string Check(RequestBody body)
        {

            return ("Количество элементов в стеке: " + tempStackList[body.Number].Count);
        }

        [HttpPost("Push")]
        public string Push(RequestBody body)
        {
            tempStackList[body.Number].Push(body.Element);
            return "Добавлен элемент: " + body.Element;
        }

        [HttpPost("Peek")]
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

        [HttpPost("Pop")]
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
