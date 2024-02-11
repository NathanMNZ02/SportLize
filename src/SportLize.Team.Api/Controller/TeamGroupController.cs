using Microsoft.AspNetCore.Mvc;
using SportLize.Team.Api.Team.Business.Abstraction;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeamGroupController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TeamGroupController(IBusiness business, ILogger<TeamGroupController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpPost(Name = "InsertGroup")]
        public async Task<ActionResult> InsertGroup(GroupWriteDto groupWriteDto)
        {
            return Ok(await _business.InsertGroup(groupWriteDto));
        }

        [HttpPut(Name = "UpdateGroup")]
        public async Task<ActionResult> UpdateGroup([FromBody] GroupReadDto oldGroup, [FromQuery] GroupWriteDto newGroup)
        {
            return Ok(await _business.UpdateGroup(oldGroup, newGroup));
        }

        [HttpGet(Name = "GetAllGroup")]
        public async Task<ActionResult> GetAllGroup()
        {
            return Ok(await _business.GetAllGroup());
        }

        [HttpGet(Name = "GetGroup")]
        public async Task<ActionResult> GetGroup(int id)
        {
            return Ok(await _business.GetGroup(id));
        }

        [HttpDelete(Name = "DeleteGroup")]
        public async Task<ActionResult> DeleteGroup(GroupReadDto groupReadDto)
        {
            return Ok(await _business.DeleteGroup(groupReadDto));
        }
    }
}
