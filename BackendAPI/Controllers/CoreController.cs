using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library.Communication;
using Library.Model.Book;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("core")]
    public class CoreController : ControllerBase
    {
        private readonly IRepository _repository;

        public CoreController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<ITrackedArray<ICoreSpellBook>> All()
        {
            //var arr = new[]
            //{
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfLight),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfDarkness),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfCreation),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfDestruction),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfAir),
            //    await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfWater),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfFire),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfEarth),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfEssence),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfIllusion),
            //    //await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfNecromancy)
            //};

            //return new TrackedArray<ICoreSpellBook>(arr);
            return new TrackedArray<ICoreSpellBook>(await _repository.GetAllAsync<ICoreSpellBook>());
        }

        [HttpGet("light")]
        public async Task<ITrackedObject<ICoreSpellBook>> Light()
        {
            return await GetBook(Identification.BookOfLight);
        }

        [HttpGet("darkness")]
        public async Task<ITrackedObject<ICoreSpellBook>> Darkness()
        {
            return await GetBook(Identification.BookOfDarkness);
        }

        [HttpGet("creation")]
        public async Task<ITrackedObject<ICoreSpellBook>> Creation()
        {
            return await GetBook(Identification.BookOfCreation);
        }

        [HttpGet("destruction")]
        public async Task<ITrackedObject<ICoreSpellBook>> Destruction()
        {
            return await GetBook(Identification.BookOfDestruction);
        }

        [HttpGet("fire")]
        public async Task<ITrackedObject<ICoreSpellBook>> Fire()
        {
            return await GetBook(Identification.BookOfFire);
        }

        [HttpGet("water")]
        public async Task<ITrackedObject<ICoreSpellBook>> Water()
        {
            return await GetBook(Identification.BookOfWater);
        }

        [HttpGet("earth")]
        public async Task<ICoreSpellBook> Earth()
        {
            //return await GetBook(Identification.BookOfEarth);
            return await _repository.GetAsync<ICoreSpellBook>(Identification.BookOfEarth);
        }

        [HttpGet("air")]
        public async Task<ITrackedObject<ICoreSpellBook>> Air()
        {
            return await GetBook(Identification.BookOfAir);
        }

        [HttpGet("essence")]
        public async Task<ITrackedObject<ICoreSpellBook>> Essence()
        {
            return await GetBook(Identification.BookOfEssence);
        }

        [HttpGet("illusion")]
        public async Task<ITrackedObject<ICoreSpellBook>> Illusion()
        {
            return await GetBook(Identification.BookOfIllusion);
        }

        [HttpGet("necromancy")]
        public async Task<ITrackedObject<ICoreSpellBook>> Necromancy()
        {
            return await GetBook(Identification.BookOfNecromancy);
        }

        private async Task<ITrackedObject<ICoreSpellBook>> GetBook(string id)
        {
            var spellBook = await _repository.GetAsync<ICoreSpellBook>(id);
            return new TrackedObject<ICoreSpellBook>(spellBook);
        }
    }
}