using System.Collections.Generic;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Book
{
    [TableInterface]
    public interface ISubPath : IDatabaseEntity
    {
        string Name { get; }
        string School { get; }

        ICollection<ISubPathSpell> Spells { get; }
    }
}