using System.Threading.Tasks;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Shared;
using Library.Communication;
using Microsoft.AspNetCore.Mvc;

namespace MageAPI.Controllers
{
    [ApiController]
    [Route("arcanum")]
    public class ArcanumController : ControllerBase
    {
        private readonly IRepository _repository;

        public ArcanumController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<ITrackedArray<IArcanum>> All()
        {
            return new TrackedArray<IArcanum>(await _repository.GetAllAsync<IArcanum>());
        }
    }
}