using System.Threading.Tasks;
using Interfaces.Model.Anima.Book;

namespace Interfaces.Model.Anima
{
    public interface ICoreSpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> BySpell(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> ByTag(string[] filter, ICoreSpellBook spellBook);
        ValueTask<ICoreSpellBook> BySpecial(string[] filters, ICoreSpellBook spellBook);
    }
}