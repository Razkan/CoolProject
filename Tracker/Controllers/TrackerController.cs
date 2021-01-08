using Interfaces.Model;
using Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("tracker")]
    public class TrackerController : ControllerBase
    {
        private readonly ICache _cache;

        public TrackerController(ICache cache)
        {
            _cache = cache;
        }

        [HttpPost("post")]
        public void Post([FromBody] TrackEndpoint data)
        {
            _cache.Store(data.TInterface, data.Uri);
        }

        [HttpGet("get")]
        public IEndpoint Get([FromBody] EndpointInfo endpointInfo)
        {
            return _cache.Get(endpointInfo.Type);
        }
    }
}
