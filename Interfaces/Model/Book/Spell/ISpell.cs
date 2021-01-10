using System.Collections.Generic;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Enum;

namespace Interfaces.Model.Book.Spell
{
    [TableInterface]
    public interface ISpell : IDatabaseEntity
    {
        string Name { get; }
        SpellAction Action { get; }
        long Level { get; }
        long Cost { get; }
        string Effect { get; }
        string AddedEffect { get; }
        string MaximumZeon { get; }
        CharacterAttribute ZeonAttribute { get; }
        string Maintenance { get; }
        MaintenanceDuration MaintenanceDuration { get; }
        IEnumerable<SpellType> Type { get; }
        IEnumerable<IResistance> Resistances { get; }
        IEnumerable<Tag> Tags { get; }
    }
}