using Microsoft.AspNetCore.Mvc;
using SportLize.Team.Api.Team.Business.Abstraction;
using SportLize.Team.Api.Team.Repository.Model;

namespace SportLize.Team.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeamUserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TeamUserController(IBusiness business, ILogger<TeamGroupController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpPost(Name = "InsertUserToGroup")]
        public async Task<ActionResult> InsertUserToGroup([FromQuery] int groupId, [FromBody] UserKafka userKafka) =>
            Ok(await _business.InsertUserToGroup(groupId, userKafka));

        [HttpPost(Name = "GetAllUserKafkaOfGroup")]
        public async Task<ActionResult> GetAllUserKafkaOfGroup(int groupId) =>
            Ok(await _business.GetAllUserKafkaOfGroup(groupId));

        [HttpPost(Name = "GetAllUserKafka")]
        public async Task<ActionResult> GetAllUserKafka() =>
            Ok(await _business.GetAllUserKafka());
    }
}
