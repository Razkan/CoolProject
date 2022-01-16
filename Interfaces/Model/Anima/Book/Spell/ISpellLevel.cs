using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Anima.Book.Spell
{
    [TableInterface]
    public interface ISpellLevel : IDatabaseEntity
    {
        string Name { get; }
        long Zeon { get; }
        long IntellectRequirement { get; }
        string Effect { get; }
        long Maintenance { get; }
    }
}