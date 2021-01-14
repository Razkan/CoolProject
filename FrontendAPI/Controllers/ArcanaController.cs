using System.Collections.Generic;
using Interfaces.Model.Book;
using Interfaces.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers
{
    [ApiController]
    [Route("arcana")]
    public class ArcanaController : ControllerBase
    {
        private readonly IRemoteProcedureCall _remoteProcedureCall;
        private readonly ICoreSpellBookFilter _coreSpellBookFilter;

        public ArcanaController(
            IRemoteProcedureCall remoteProcedureCall,
            ICoreSpellBookFilter coreSpellBookFilter)
        {
            _remoteProcedureCall = remoteProcedureCall;
            _coreSpellBookFilter = coreSpellBookFilter;
        }

        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<IArcanaSpellBook> All(
            [FromQuery] string[] contains,
            [FromQuery] string[] schools,
            [FromQuery] string[] tags,
            [FromQuery] string[] specials)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Content-Type", "application/json");
            var result = await _remoteProcedureCall.GetAsync<IArcanaSpellBook>();
            var filteredResult = result.GetResult<IArcanaSpellBook>();

            //var filteredResult = result.GetResult<ISubPath>()
            //    .WhereAwait(spellBook => _spellBookFilter.BySchool(schools, spellBook))
            //    .SelectAwait(spellBook => _spellBookFilter.BySpell(contains, spellBook))
            //    .SelectAwait(spellBook => _spellBookFilter.ByTag(tags, spellBook))
            //    .SelectAwait(spellBook => _spellBookFilter.BySpecial(specials, spellBook))
            //    .WhereAwait(spellBook => new ValueTask<bool>(spellBook.Spells != null && spellBook.Spells.Any()));

            await foreach (var filterResult in filteredResult)
            {
                yield return filterResult;
            }
        }
    }
}