using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiServerCSharp.Models;

namespace ApiServerCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private static readonly List<Message> messages = new List<Message>();

        [HttpPost("send-message")]
        public IActionResult SendMessage(Message message)
        {
            messages.Add(message);
            return Ok(new { Message = "Message received" });
        }

        [HttpGet("get-messages")]
        public IActionResult GetMessages()
        {
            return Ok(messages);
        }
    }
}
