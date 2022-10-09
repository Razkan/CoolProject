﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Model.Anima;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers.Anima
{
    [ApiController]
    [Route("anima/core")]
    public class CoreController : ControllerBase
    {
        private readonly IRemoteProcedureCall _remoteProcedureCall;
        private readonly ICoreSpellBookFilter _coreSpellBookFilter;

        public CoreController(
            IRemoteProcedureCall remoteProcedureCall,
            ICoreSpellBookFilter coreSpellBookFilter)
        {
            _remoteProcedureCall = remoteProcedureCall;
            _coreSpellBookFilter = coreSpellBookFilter;
        }


        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<ICoreSpellBook> All(
            [FromQuery] string[] contains,
            [FromQuery] string[] schools,
            [FromQuery] string[] tags,
            [FromQuery] string[] specials)
        {
            var result = await _remoteProcedureCall.GetAsync<ICoreSpellBook>();

            Response.Headers.Add("Content-Type", "application/json");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var filteredResult = result.GetResult<ICoreSpellBook>()
                .WhereAwait(spellBook => _coreSpellBookFilter.BySchool(schools, spellBook))
                .SelectAwait(spellBook => _coreSpellBookFilter.BySpell(contains, spellBook))
                .SelectAwait(spellBook => _coreSpellBookFilter.ByTag(tags, spellBook))
                .SelectAwait(spellBook => _coreSpellBookFilter.BySpecial(specials, spellBook))
                .WhereAwait(spellBook => new ValueTask<bool>(spellBook.Spells != null && spellBook.Spells.Any()));

            await foreach (var filterResult in filteredResult)
            {
                yield return filterResult;
            }
        }

        [Route("test")]
        public async Task Test()
        {
            var result = await _remoteProcedureCall.GetAsync<ICoreSpellBook>();
            
            Response.Headers.Add("Content-Type", "application/json");
            await foreach (var stream in result.GetStreams())
            {
                await stream.CopyToAsync(HttpContext.Response.Body);
            }
        }

        [HttpGet]
        [Route("earth")]
        public async Task<IRPCResponse> Earth()
        {
            Response.Headers.Add("Content-Type", "application/json");
            return await _remoteProcedureCall.GetAsync<IBookOfEarth>();
        }

        [HttpGet]
        [Route("illusion")]
        public async Task<IRPCResponse> Illusion()
        {
            Response.Headers.Add("Content-Type", "application/json");
            return await _remoteProcedureCall.GetAsync<IBookOfIllusion>();
        }
    }
}