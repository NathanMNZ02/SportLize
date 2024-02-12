using Microsoft.AspNetCore.Mvc;
using SportLize.Team.Api.Team.Business.Abstraction;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeamMessageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TeamMessageController(IBusiness business, ILogger<TeamMessageController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpPost(Name = "InsertMessage")]
        public async Task<ActionResult> InsertMessageToGroup([FromQuery] int groupId, MessageWriteDto messageWriteDto)
        {
            return Ok(await _business.InsertMessageToGroup(groupId, messageWriteDto));
        }

        [HttpPut(Name = "UpdateMessage")]
        public async Task<ActionResult> UpdateMessage([FromBody] MessageReadDto messageReadDto)
        {
            return Ok(await _business.UpdateMessage(messageReadDto));
        }

        [HttpGet(Name = "GetAllMessagesOfGroup")]
        public async Task<ActionResult> GetAllMessagesOfGroup(int groupId)
        {
            return Ok(await _business.GetAllMessagesOfGroup(groupId));
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
