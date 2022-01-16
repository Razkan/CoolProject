using System.Threading.Tasks;
using Interfaces.Model.Anima.Book;

namespace Interfaces.Model.Anima
{
    public interface IArcanaSpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> BySpell(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> ByTag(string[] filter, IArcanaSpellBook spellBook);
        ValueTask<IArcanaSpellBook> BySpecial(string[] filters, IArcanaSpellBook spellBook);
    }
}