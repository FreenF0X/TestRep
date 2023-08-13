using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("lists")]
    public class ListController : Controller
    {
        List<List<String>> tempListList;

        public ListController(List<List<String>> StaсkList)
        {
            tempListList = StaсkList;
        }

        [HttpPost]
        public ResponseBody CreateNewList()
        {
            tempListList.Add(new List<string>());
            return new ResponseBody { Response = "Новый лист создан." };
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteList(int id)
        {
            tempListList.RemoveAt(id);
            return new ResponseBody { Response = ("Лист номер: " + id + " удален.") };
        }

        [HttpGet("count")]
        public ResponseBody CountOfLists()
        {
            return new ResponseBody { Response = "Количество листов: " + tempListList.Count };
        }

        [HttpGet("check/{id}")]
        public ResponseBody Check(int id)
        {
            return new ResponseBody { Response = ("Количество элементов с листе: " + tempListList[id].Count) };
        }

        [HttpPost("add/{id}")]
        public ResponseBody Add(int id, RequestBody body)
        {
            tempListList[id].Add(body.Element);
            return new ResponseBody { Response = "Добавлен элемент: " + body.Element };
        }

        [HttpGet("read/{idStruct}/{idElement}")]
        public ResponseBody Read(int idStruct, int idElement)
        {
            try
            {
                return new ResponseBody { Response = ("Элемент: " + tempListList[idStruct][idElement]) };
            }
            catch (Exception e)
            {
                return new ResponseBody { Response = e.Message };
            }
        }

        [HttpPost("remove/{idStruct}/{idElement}")]
        public ResponseBody Remove(int idStruct, int idElement)
        {
            try
            {
                tempListList[idStruct].RemoveAt(idElement);
                return new ResponseBody { Response = "Элемент удален" };
            }
            catch (Exception e)
            {
                return new ResponseBody { Response = e.Message };
            }
        }


    }
}
