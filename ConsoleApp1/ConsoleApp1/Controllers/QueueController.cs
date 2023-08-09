using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("queues")]
    public class QueueController : Controller
    {
        List<Queue<String>> tempQueueList;

        public QueueController(List<Queue<String>> QueueList)
        {
            tempQueueList = QueueList;
        }

        [HttpPost]
        public ResponseBody CreateNewQueue()
        {
            tempQueueList.Add(new Queue<string>());
            return new ResponseBody { Response = "Новая очередь создана." };
        }

        [HttpDelete("{id}")]
        public ResponseBody DeleteQueue(int id)
        {

            tempQueueList.RemoveAt(id);
            return new ResponseBody { Response = "Очередь номер: " + id + " удалена." };
        }

        [HttpGet("count")]
        public ResponseBody CountOfQueues()
        {
            return new ResponseBody { Response = "Количество очередей: " + tempQueueList.Count };
        }

        [HttpGet("check/{id}")]
        public ResponseBody Check(int id)
        {

            return new ResponseBody { Response = ("Количество элементов в очереди: " + tempQueueList[id].Count) };
        }

        [HttpPost("enqueue/{id}")]
        public ResponseBody Enqueue(int id, RequestBody body)
        {
            tempQueueList[id].Enqueue(body.Element);
            return new ResponseBody { Response = "Добавлен элемент: " + body.Element };
        }

        [HttpGet("peek/{id}")]
        public ResponseBody Peek(int id)
        {
            try
            {
                return new ResponseBody { Response = tempQueueList[id].Peek().ToString() };
            }
            catch (Exception ex)
            {
                return new ResponseBody { Response = ex.Message };
            }
        }

        [HttpGet("dequeue/{id}")]
        public ResponseBody Dequeue(int id)
        {
            try
            {
                return new ResponseBody { Response = tempQueueList[id].Dequeue().ToString() };
            }
            catch (Exception ex)
            {
                return new ResponseBody { Response = ex.Message };
            }
        }
    }
}
