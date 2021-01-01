using Interfaces.Model;
using Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("tracker")]
    public class TrackerController : ControllerBase
    {
        private readonly IStorage _storage;

        public TrackerController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("post")]
        public void Post([FromBody] Store data)
        {
            _storage.Store(data.TInterface, data.Uri);
        }

        [HttpGet("get")]
        public IFetch Get([FromBody] TrackerInfo trackerInfo)
        {
            return _storage.Get(trackerInfo.Type);
        }
    }
}
