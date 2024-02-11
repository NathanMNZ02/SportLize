using Microsoft.AspNetCore.Mvc;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TalkChatController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TalkChatController(IBusiness business, ILogger<TalkChatController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpPost(Name = "InsertChatForSender")]
        public async Task<ActionResult> InsertChatForSender([FromQuery] int userId, [FromBody] ChatWriteDto chatWriteDto)
        {
            return Ok(await _business.InsertChatForSender(userId, chatWriteDto));
        }

        [HttpPost(Name = "InsertChatForReceiver")]
        public async Task<ActionResult> InsertChatForReceiver([FromQuery]  int userId, [FromBody] ChatWriteDto chatWriteDto)
        {
            return Ok(await _business.InsertChatForReceiver(userId, chatWriteDto));
        }

        [HttpPut(Name = "UpdateChat")]
        public async Task<ActionResult> UpdateChat([FromBody] ChatReadDto chatReadDto)
        {
            return Ok(await _business.UpdateChat(chatReadDto));
        }

        [HttpGet(Name = "GetAllSentChatOfUser")]
        public async Task<ActionResult> GetAllSentChatOfUser(int userId)
        {
            return Ok(await _business.GetAllSentChatOfUser(userId));
        }

        [HttpGet(Name = "GetAllReceivedChatOfUser")]
        public async Task<ActionResult> GetAllReceivedChatOfUser(int userId)
        {
            return Ok(await _business.GetAllReceivedChatOfUser(userId));
        }

        [HttpGet(Name = "GetChat")]
        public async Task<ActionResult> GetChat(int id)
        {
            return Ok(await _business.GetChat(id));
        }

        [HttpDelete(Name = "DeleteChat")]
        public async Task<ActionResult> DeleteChat(ChatReadDto chatReadDto)
        {
            return Ok(await _business.DeleteChat(chatReadDto));
        }
    }

}
