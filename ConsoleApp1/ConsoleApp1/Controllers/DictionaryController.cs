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

    }
}
