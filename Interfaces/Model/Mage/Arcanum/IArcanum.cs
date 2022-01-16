using System.Collections.Generic;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Mage.Arcanum.Spell;

namespace Interfaces.Model.Anima.Book
{
    [TableInterface]
    public interface IArcanum : IDatabaseEntity
    {
        string Name { get; }
        string School { get; }

        [DbObjectCollection]
        ICollection<IArcanumSpell> Spells { get; }
    }
}