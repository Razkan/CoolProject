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

        MaintenanceDuration MaintenanceDuration { get; }

        [DbObjectCollection]
        IEnumerable<ISpellLevel> SpellLevel { get; }

        [DbPrimitiveCollection]
        IEnumerable<SpellType> Type { get; }

        [DbObjectCollection]
        IEnumerable<IResistance> Resistances { get; }

        [DbPrimitiveCollection]
        IEnumerable<Tag> Tags { get; }
    }
}