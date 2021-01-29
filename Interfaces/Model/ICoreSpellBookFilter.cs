using System.Threading.Tasks;
using Interfaces.Model.Book;

namespace Interfaces.Model
{
    public interface ICoreSpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> BySpell(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> ByTag(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> BySpecial(string[] filter, ICoreSpellBook spellBook);
    }
}