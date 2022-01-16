using System.Collections.Generic;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Anima.Book
{
    [TableInterface]
    public interface ICoreSpellBook : IDatabaseEntity
    {
        string Name { get; }
        string School { get; }

        [DbObjectCollection]
        ICollection<ICoreSpell> Spells { get; }
    }
}