//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System;

//namespace ConsoleApp1.Controllers
//{
//    [ApiController]
//    [Route("List")]
//    public class ListController : Controller
//    {
//        List<List<String>> tempListList;

//        public ListController(List<List<String>> StaсkList)
//        {
//            tempListList = StaсkList;
//        }

//        [HttpGet("CreateNewList")]
//        public string CreateNewList()
//        {
//            tempListList.Add(new List<string>());
//            return "Новый лист создан.";
//        }

//        [HttpPost("DeleteList")]
//        public string DeleteList(RequestBody body)
//        {
//            tempListList.RemoveAt(body.Number);
//            return ("Лист номер: " + body.Number + " удален.");
//        }

//        [HttpGet("CountOfLists")]
//        public string CountOfLists()
//        {
//            return "Количество листов: " + tempListList.Count;
//        }

//        [HttpPost("Check")]
//        public string Check(RequestBody body)
//        {
//            return ("Количество элементов с листе: " + tempListList[body.Number].Count);
//        }

//        [HttpPost("Add")]
//        public string Add(RequestBody body)
//        {
//            tempListList[body.Number].Add(body.Element);
//            return "Добавлен элемент: " + body.Element;
//        }

//        [HttpPost("Read")]
//        public string Read(RequestBody body)
//        {
//            return ("Элемент: " + tempListList[body.Number][body.I]);
//        }

//        [HttpPost("Remove")]
//        public string Remove(RequestBody body)
//        {
//            tempListList[body.Number].RemoveAt(body.I);
//            return "Элемент удален";
//        }


//    }
//}
