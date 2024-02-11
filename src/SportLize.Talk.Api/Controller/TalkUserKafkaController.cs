using Microsoft.AspNetCore.Mvc;
using SportLize.Talk.Api.Talk.Business.Abstraction;

namespace SportLize.Talk.Api.Controller
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TalkUserKafkaController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBusiness _business;

        public TalkUserKafkaController(IBusiness business, ILogger<TalkMessageController> logger)
        {
            _business = business;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllUserKafka")]
        public async Task<ActionResult> GetAllUsers()
        {
            return Ok(await _business.GetAllUsers());
        }
    }
}
