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
        List<Stack<String>> tempStakList;

        public StackController(List<Stack<String>> StakList)
        {
            tempStakList = StakList;
        }

        [HttpPost("Check")]
        public string Check(RequestBody body)
        {

            return ("Количество элементов в стаке: " +tempStakList[body.NumberOfStack].Count);
        }

        [HttpPost("DeleteStack")]
        public string DeleteStack(RequestBody body)
        {
            tempStakList.RemoveAt(body.NumberOfStack);
            return ("Стак номер: " + body.NumberOfStack + " удален.");
        }

        [HttpGet("CreateNewStack")]
        public string CreateNewStack()
        {
            tempStakList.Add(new Stack<string>());
            return "Новый стак создан.";
        }

        [HttpGet("CountOfStacks")]
        public string CountOfStacks()
        {
            return "Количество стаков: " + tempStakList.Count;
        }

        [HttpPost("Push")]
        public string Push(RequestBody body)
        {
            tempStakList[body.NumberOfStack].Push(body.Element);
            return "Добавлен элемент: " + tempStakList[0].Peek();
        }

        [HttpPost("Peek")]
        public string Peek(RequestBody body)
        {
            try
            {
                return tempStakList[body.NumberOfStack].Peek().ToString();
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
                return tempStakList[body.NumberOfStack].Pop().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }

    public class RequestBody
    {        
        public int NumberOfStack { get; set; }
        public string Element { get; set; }
    }

}
