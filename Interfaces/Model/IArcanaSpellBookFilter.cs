using System.Threading.Tasks;
using Interfaces.Model.Book;

namespace Interfaces.Model
{
    public interface IArcanaSpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> BySpell(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> ByTag(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> BySpecial(string[] filter, IArcanaSpellBook spellBook);
    }
}