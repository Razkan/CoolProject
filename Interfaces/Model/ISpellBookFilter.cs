using System.Threading.Tasks;
using Interfaces.Model.Book;

namespace Interfaces.Model
{
    public interface ISpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, ISpellBook spellBook);
        ValueTask<ISpellBook> BySpell(string[] filter, ISpellBook spellBook);
        ValueTask<ISpellBook> ByTag(string[] filter, ISpellBook spellBook);
        ValueTask<ISpellBook> BySpecial(string[] filter, ISpellBook spellBook);
    }
}