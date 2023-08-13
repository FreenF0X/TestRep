using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("dictionaris")]
    public class DictionaryController : Controller
    {
        List<Dictionary<int, String>> tempDictionaryList;

        public DictionaryController(List<Dictionary<int, String>> DictionaryList)
        {
            tempDictionaryList = DictionaryList;
        }

        [HttpPost]
        public ResponseBody CreateNewDictionary()
        {
            tempDictionaryList.Add(new Dictionary<int, string>());
            return new ResponseBody { Response = "Новый словарь создан." };
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteDictionary(int id)
        {
            tempDictionaryList.RemoveAt(id);
            return new ResponseBody { Response = "Солварь удален" };
        }

        [HttpGet]
        public ResponseBody CountOfDictionary()
        {
            return new ResponseBody { Response = "Количество словарей: " + tempDictionaryList.Count };

        }

        [HttpGet("check/{id}")]
        public ResponseBody Check(int id) 
        {
            return new ResponseBody { Response = "Количество элементов в словаре: " + tempDictionaryList[id].Count };
        }

        [HttpPost("add/{id}/{key}")]
        public ResponseBody Add(int id,int key, RequestBody body)
        {
            tempDictionaryList[id].Add(key, body.Element);
            return new ResponseBody { Response = "Добавлен элемент. Ключ: "+ key +". Значение: " + body.Element  };
        }

        [HttpGet("read/{id}/{key}")]
        public ResponseBody Read(int id, int key)
        {
            try
            {
                return new ResponseBody { Response = ("Элемент: " + tempDictionaryList[id][key]) };
            }
            catch (Exception e)
            {
                return new ResponseBody { Response = e.Message };
            }
        }

        [HttpPost("remove/{id}/{key}")]
        public ResponseBody Remove(int id, int key)
        {
            try
            {
                tempDictionaryList[id].Remove(key);
                return new ResponseBody { Response = "Элемент удален" };   
            }
            catch (Exception e)
            {
                return new ResponseBody { Response = e.Message };
            }
        }

    }
}
