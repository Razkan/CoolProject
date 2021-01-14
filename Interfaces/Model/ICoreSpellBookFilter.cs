using System.Threading.Tasks;
using Interfaces.Model.Book;

namespace Interfaces.Model
{
    public interface ICoreSpellBookFilter
    {
        ValueTask<bool> BySchool(string[] filter, ICoreSpellBook coreSpellBook);
        ValueTask<ICoreSpellBook> BySpell(string[] filter, ICoreSpellBook coreSpellBook);
        ValueTask<ICoreSpellBook> ByTag(string[] filter, ICoreSpellBook coreSpellBook);
        ValueTask<ICoreSpellBook> BySpecial(string[] filter, ICoreSpellBook coreSpellBook);
    }
}