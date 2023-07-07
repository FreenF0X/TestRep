using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("Queue")]
    public class QueueController : Controller
    {
        List<Queue<String>> tempQueueList;

        public QueueController(List<Queue<String>> QueueList)
        {
            tempQueueList = QueueList;
        }

        [HttpGet("CreateNewQueue")]
        public string CreateNewQueue()
        {
            tempQueueList.Add(new Queue<string>());
            return "Новая очередь создана.";
        }

        [HttpPost("DeleteQueue")]
        public string DeleteQueue(RequestBody body)
        {
            tempQueueList.RemoveAt(body.Number);
            return ("Очередь номер: " + body.Number + " удален.");
        }

        [HttpGet("CountOfQueues")]
        public string CountOfQueues()
        {
            return "Количество очередей: " + tempQueueList.Count;
        }

        [HttpPost("Check")]
        public string Check(RequestBody body)
        {

            return ("Количество элементов в очереди: " + tempQueueList[body.Number].Count);
        }

        [HttpPost("Enqueue")]
        public string Enqueue(RequestBody body)
        {
            tempQueueList[body.Number].Enqueue(body.Element);
            return "Добавлен элемент: " + body.Element;
        }

        [HttpPost("Peek")]
        public string Peek(RequestBody body)
        {
            try
            {
                return tempQueueList[body.Number].Peek().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Dequeue")]
        public string Dequeue(RequestBody body)
        {
            try
            {
                return tempQueueList[body.Number].Dequeue().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
