using System.Collections.Generic;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Enum;

namespace Interfaces.Model.Book.Spell
{
    [TableInterface]
    public interface IArcanaSpell : IDatabaseEntity
    {
        string Name { get; }
        SpellAction Action { get; }
        long Level { get; }
        string Effect { get; }
        IEnumerable<ISpellLevel> SpellLevel { get; }
        MaintenanceDuration MaintenanceDuration { get; }
        IEnumerable<SpellType> Type { get; }
        IEnumerable<IResistance> Resistances { get; }
        IEnumerable<Tag> Tags { get; }
    }
}