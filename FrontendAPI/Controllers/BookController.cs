using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Model.Book;
using System.Linq;
using Interfaces.Model;
using Interfaces.Model.Book.Spell;
using Microsoft.AspNetCore.Mvc;

namespace FrontendAPI.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IRemoteProcedureCall _remoteProcedureCall;
        private readonly ISpellBookFilter _spellBookFilter;

        public BookController(
            IRemoteProcedureCall remoteProcedureCall,
            ISpellBookFilter spellBookFilter)
        {
            _remoteProcedureCall = remoteProcedureCall;
            _spellBookFilter = spellBookFilter;
        }

        [HttpGet]
        [Route("all")]
        public async IAsyncEnumerable<ISpellBook> All(
            [FromQuery] string[] contains,
            [FromQuery] string[] schools,
            [FromQuery] string[] tags,
            [FromQuery] string[] specials)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Content-Type", "application/json");
            var result = await _remoteProcedureCall.GetAsync<ISpellBook>();

            var filteredResult = result.GetResult<ISpellBook>()
                .WhereAwait(spellBook => _spellBookFilter.BySchool(schools, spellBook))
                .SelectAwait(spellBook => _spellBookFilter.BySpell(contains, spellBook))
                .SelectAwait(spellBook => _spellBookFilter.ByTag(tags, spellBook))
                .SelectAwait(spellBook => _spellBookFilter.BySpecial(specials, spellBook))
                .WhereAwait(spellBook => new ValueTask<bool>(spellBook.Spells != null && spellBook.Spells.Any()));

            filteredResult = filteredResult.OrderBy(spellBook => spellBook.Name);

            await foreach (var filterResult in filteredResult)
            {
                yield return OrderBy(filterResult);
            }

            ISpellBook OrderBy(ISpellBook book)
            {
                var spellList = new List<ISpell>(book.Spells);
                var orderSpellList = spellList.OrderBy(spell => spell.Level).ThenBy(spell => spell.Cost);
                book.Spells.Clear();

                foreach (var spell in orderSpellList)
                {
                    book.Spells.Add(spell);
                }

                return book;
            }
        }

        [HttpGet]
        [Route("earth")]
        public async Task<IRPCResponse> Earth()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Content-Type", "application/json");
            return await _remoteProcedureCall.GetAsync<IBookOfEarth>();
        }

        [HttpGet]
        [Route("illusion")]
        public async Task<IRPCResponse> Illusion()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Content-Type", "application/json");
            return await _remoteProcedureCall.GetAsync<IBookOfIllusion>();
        }

        //[HttpGet]
        //public async Task<Stream> Chaos()
        //{
        //    return await RemoteProcedureCall.GetAsync<IUser>();
        //}
    }
}