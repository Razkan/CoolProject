﻿using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library.Communication;
using Library.Model.Book;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IRepository _repository;

        public BookController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("All")]
        public async Task<ITrackedArray<ISpellBook>> All()
        {
            var arr = new[]
            {
                await _repository.GetAsync<ISpellBook>(Identification.BookOfLight),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfDarkness),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfCreation),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfDestruction),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfAir),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfWater),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfFire),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfEarth),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfEssence),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfIllusion),
                await _repository.GetAsync<ISpellBook>(Identification.BookOfNecromancy)
            };

            return new TrackedArray<ISpellBook>(arr);
        }

        [HttpGet("light")]
        public async Task<ITrackedObject<ISpellBook>> Light()
        {
            return await GetBook(Identification.BookOfLight);
        }

        [HttpGet("darkness")]
        public async Task<ITrackedObject<ISpellBook>> Darkness()
        {
            return await GetBook(Identification.BookOfDarkness);
        }

        [HttpGet("creation")]
        public async Task<ITrackedObject<ISpellBook>> Creation()
        {
            return await GetBook(Identification.BookOfCreation);
        }

        [HttpGet("destruction")]
        public async Task<ITrackedObject<ISpellBook>> Destruction()
        {
            return await GetBook(Identification.BookOfDestruction);
        }

        [HttpGet("fire")]
        public async Task<ITrackedObject<ISpellBook>> Fire()
        {
            return await GetBook(Identification.BookOfFire);
        }

        [HttpGet("water")]
        public async Task<ITrackedObject<ISpellBook>> Water()
        {
            return await GetBook(Identification.BookOfWater);
        }

        [HttpGet("earth")]
        public async Task<ITrackedObject<ISpellBook>> Earth()
        {
            return await GetBook(Identification.BookOfEarth);
        }

        [HttpGet("air")]
        public async Task<ITrackedObject<ISpellBook>> Air()
        {
            return await GetBook(Identification.BookOfAir);
        }

        [HttpGet("essence")]
        public async Task<ITrackedObject<ISpellBook>> Essence()
        {
            return await GetBook(Identification.BookOfEssence);
        }

        [HttpGet("illusion")]
        public async Task<ITrackedObject<ISpellBook>> Illusion()
        {
            return await GetBook(Identification.BookOfIllusion);
        }

        [HttpGet("necromancy")]
        public async Task<ITrackedObject<ISpellBook>> Necromancy()
        {
            return await GetBook(Identification.BookOfNecromancy);
        }

        private async Task<ITrackedObject<ISpellBook>> GetBook(string id)
        {
            var spellBook = await _repository.GetAsync<ISpellBook>(id);
            return new TrackedObject<ISpellBook>(spellBook);
        }
    }
}