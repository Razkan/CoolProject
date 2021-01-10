using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library.Communication;
using Library.Model.Book;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("subpath")]
    public class SubPathController : ControllerBase
    {
        private readonly IRepository _repository;

        public SubPathController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("All")]
        public async Task<ITrackedArray<ISubPath>> All()
        {
            var arr = new[]
            {
                await _repository.GetAsync<ISubPath>(Identification.Nobility),
            };

            return new TrackedArray<ISubPath>(arr);
        }

        [HttpGet("nobility")]
        public async Task<ITrackedObject<ISubPath>> Nobility()
        {
            return await GetSubPath(Identification.Nobility);
        }

        private async Task<ITrackedObject<ISubPath>> GetSubPath(string id)
        {
            var subPath = await _repository.GetAsync<ISubPath>(id);
            return new TrackedObject<ISubPath>(subPath);
        }
    }
}