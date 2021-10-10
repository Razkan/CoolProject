using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Response.Headers.Add("Content-Type", "application/json");
            var result = await _remoteProcedureCall.GetAsync<IArcanaSpellBook>();

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