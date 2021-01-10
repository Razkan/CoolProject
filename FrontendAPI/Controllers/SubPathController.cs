using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Model.Book;
using System.Linq;
using Interfaces.Model;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers
{
    [ApiController]
    [Route("subpath")]
    public class SubPathController : ControllerBase
    {
        private readonly IRemoteProcedureCall _remoteProcedureCall;
        private readonly ISpellBookFilter _spellBookFilter;

        public SubPathController(
            IRemoteProcedureCall remoteProcedureCall,
            ISpellBookFilter spellBookFilter)
        {
            _remoteProcedureCall = remoteProcedureCall;
            _spellBookFilter = spellBookFilter;
        }

        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<ISubPath> All(
            [FromQuery] string[] contains,
            [FromQuery] string[] schools,
            [FromQuery] string[] tags,
            [FromQuery] string[] specials)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Content-Type", "application/json");
            var result = await _remoteProcedureCall.GetAsync<ISubPath>();
            var filteredResult = result.GetResult<ISubPath>();

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