using logger = Log.Service.Api.Logger;
using Log.Service.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Log.Service.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly logger.ILogger _logger;

        public LogController(logger.ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public IActionResult Index([FromBody] Data data)
        {
            var json = JsonConvert.SerializeObject(data);

            _logger.Log(data.Type, json);
            return Ok();
        }
    }
}