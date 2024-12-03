using DotNETChat.Dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace DotNETChat.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost("messages")]
        public async Task<ActionResult> Message(MessageDTO dto)
        {
            var options = new PusherOptions
            {
                Cluster = "ap2",
                Encrypted = true
            };

            var pusher = new Pusher(
              "1904847",
              "634646fe55346f4cbe80",
              "33de7968db3c78a2a12a",
              options);

            await pusher.TriggerAsync(
              "chat",
              "message",
              new {
                  username = dto.UserName,
                  message = dto.Message
                  });
            return Ok(new string[] {});
        }
    }
}
