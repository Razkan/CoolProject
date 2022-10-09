using System.Collections.Generic;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Mage.Arcanum.Spell;
using Interfaces.Model.Mage.Enum;

namespace Interfaces.Model.Anima.Book
{
    [TableInterface]
    public interface IArcanum : IDatabaseEntity
    {
        string Name { get; }
        School School { get; }

        [DbObjectCollection]
        ICollection<IArcanumSpell> Spells { get; }
    }
}