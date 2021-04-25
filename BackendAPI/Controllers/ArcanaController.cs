using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library.Communication;
using Library.Model.Book;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("arcana")]
    public class ArcanaController : ControllerBase
    {
        private readonly IRepository _repository;

        public ArcanaController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("all")]
        public async Task<ITrackedArray<IArcanaSpellBook>> All()
        {
            //var arr = new[]
            //{
            //    await _repository.GetAsync<IArcanaSpellBook>(Identification.Nobility),
            //};

            //return new TrackedArray<IArcanaSpellBook>(arr);
            return new TrackedArray<IArcanaSpellBook>(await _repository.GetAllAsync<IArcanaSpellBook>());
        }

        [HttpGet("nobility")]
        public async Task<ITrackedObject<IArcanaSpellBook>> Nobility()
        {
            return await GetSubPath(Identification.Nobility);
        }

        private async Task<ITrackedObject<IArcanaSpellBook>> GetSubPath(string id)
        {
            var subPath = await _repository.GetAsync<IArcanaSpellBook>(id);
            return new TrackedObject<IArcanaSpellBook>(subPath);
        }
    }
}