using Castle.Components.DictionaryAdapter;
using MessageService.Abstraction;
using MessageService.Models.Dto;
using MessageService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageSrv _messageSrv;
        public MessageController(IMessageSrv messageSrv)
        {
            _messageSrv = messageSrv;
        }

        [Authorize]
        [HttpGet("GetMessageForMe")]
        public IActionResult GetMsg()
        {
            var senderid = new Guid(HttpContext.User.Claims.Where(x => x.Type == "UserId").Select(c => c.Value).SingleOrDefault());
            var res = _messageSrv.GetMessagesForMe(senderid);
            return Ok(res);
        }
        [Authorize]
        [HttpPost("SendMessage")]
        public IActionResult SendMsg([FromBody] SendMessageModelDto message)
        {
            var senderid = new Guid(HttpContext.User.Claims.Where(x => x.Type == "UserId").Select(c => c.Value).SingleOrDefault());
            var res = _messageSrv.SendMsg(message, senderid);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
