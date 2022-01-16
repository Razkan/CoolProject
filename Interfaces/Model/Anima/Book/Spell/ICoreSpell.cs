using System.Collections.Generic;
using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Shared;

namespace Interfaces.Model.Anima.Book.Spell
{
    [TableInterface]
    public interface ICoreSpell : IDatabaseEntity
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

        [DbPrimitiveCollection]
        IEnumerable<SpellType> Type { get; }

        [DbObjectCollection]
        IEnumerable<IResistance> Resistances { get; }

        [DbPrimitiveCollection]
        IEnumerable<Tag> Tags { get; }
    }
}