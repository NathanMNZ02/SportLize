using Microsoft.AspNetCore.Mvc;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TalkMessageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TalkMessageController(IBusiness business, ILogger<TalkMessageController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpPost(Name = "InsertMessage")]
        public async Task<ActionResult> InsertMessage([FromQuery] int chatId, [FromBody] MessageWriteDto messageWriteDto)
        {
            return Ok(await _business.InsertMessageInChat(chatId, messageWriteDto));
        }

        [HttpPut(Name = "UpdateMessage")]
        public async Task<ActionResult> UpdateMessage([FromBody] MessageReadDto messageReadDto)
        {
            return Ok(await _business.UpdateMessage(messageReadDto));
        }

        [HttpGet(Name = "GetAllMessageOfChat")]
        public async Task<ActionResult> GetAllMessageOfChat(int chatId)
        {
            return Ok(await _business.GetAllMessagesOfChat(chatId));
        }

        [HttpGet(Name = "GetMessage")]
        public async Task<ActionResult> GetMessage(int id)
        {
            return Ok(await _business.GetMessage(id));
        }

        [HttpDelete(Name = "DeleteMessage")]
        public async Task<ActionResult> DeleteMessage(MessageReadDto messageReadDto)
        {
            return Ok(await _business.DeleteMessage(messageReadDto));
        }
    }

}
