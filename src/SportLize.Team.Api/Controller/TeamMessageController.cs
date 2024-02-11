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
        public async Task<ActionResult> InsertMessage(MessageWriteDto messageWriteDto)
        {
            return Ok(await _business.InsertMessage(messageWriteDto));
        }

        [HttpPut(Name = "UpdateMessage")]
        public async Task<ActionResult> UpdateMessage([FromBody] MessageReadDto oldMessage, [FromQuery] MessageWriteDto newMessage)
        {
            return Ok(await _business.UpdateMessage(oldMessage, newMessage));
        }

        [HttpGet(Name = "GetAllMessage")]
        public async Task<ActionResult> GetAllMessage(GroupReadDto groupReadDto)
        {
            return Ok(await _business.GetAllMessagesOfGroup(groupReadDto));
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
