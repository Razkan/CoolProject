using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Model.Anima;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers.Anima
{
    [ApiController]
    [Route("anima/arcana")]
    public class ArcanaController : ControllerBase
    {
        private readonly IRemoteProcedureCall _remoteProcedureCall;
        private readonly IArcanaSpellBookFilter _arcanaSpellBookFilter;

        public ArcanaController(
            IRemoteProcedureCall remoteProcedureCall,
            IArcanaSpellBookFilter arcanaSpellBookFilter)
        {
            _remoteProcedureCall = remoteProcedureCall;
            _arcanaSpellBookFilter = arcanaSpellBookFilter;
        }

        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<IArcanaSpellBook> All(
            [FromQuery] string[] contains,
            [FromQuery] string[] schools,
            [FromQuery] string[] tags,
            [FromQuery] string[] specials)
        {
            var result = await _remoteProcedureCall.GetAsync<IArcanaSpellBook>();
            
            Response.Headers.Add("Content-Type", "application/json");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var filteredResult = result.GetResult<IArcanaSpellBook>()
                .WhereAwait(spellBook => _arcanaSpellBookFilter.BySchool(schools, spellBook))
                .SelectAwait(spellBook => _arcanaSpellBookFilter.BySpell(contains, spellBook))
                .SelectAwait(spellBook => _arcanaSpellBookFilter.ByTag(tags, spellBook))
                .SelectAwait(spellBook => _arcanaSpellBookFilter.BySpecial(specials, spellBook))
                .WhereAwait(spellBook => new ValueTask<bool>(spellBook.Spells != null && spellBook.Spells.Any()));

            await foreach (var filterResult in filteredResult)
            {
                yield return filterResult;
            }
        }
    }
}