using MessagingAPI.Models;
using MessagingAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MessagingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var messages = await _messageService.GetAllMessages();

            return Ok(messages);
        }

        [HttpGet("{messageId}")]
        public async Task<IActionResult> Get(Guid messageId)
        {
            return Ok(await _messageService.GetMessage(messageId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageDTO message)
        {
            await _messageService.CreateMessage(message);

            return Ok();
        }

        [HttpPut("{messageId}")]
        public async Task<IActionResult> Put(Guid messageId, [FromBody] MessageDTO message)
        {
            await _messageService.UpdateMessage(messageId, message);

            return Ok();
        }

        [HttpDelete("{messageId}")]
        public async Task<IActionResult> Delete(Guid messageId)
        {
            await _messageService.DeleteMessage(messageId);

            return Ok();
        }
    }
}