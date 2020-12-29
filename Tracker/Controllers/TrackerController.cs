using Interfaces.Model;
using Library;
using Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackerController : ControllerBase
    {
        private readonly IStorage _storage;

        public TrackerController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpPost("store")]
        public void Post([FromBody] Store data)
        {
            _storage.Store(data.TInterface, data.Uri);
        }

        [HttpGet("info")]
        public IFetch Get([FromBody] TrackerInfo trackerInfo)
        {
            return _storage.Get(trackerInfo.Type);
        }
    }
}
