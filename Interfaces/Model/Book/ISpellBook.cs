using System.Collections.Generic;
using Interfaces.Model.Book.Spell;

namespace Interfaces.Model.Book
{
    public interface ISpellBook
    {
        string Name { get; }
        string School { get; }
        ICollection<ISpell> Spells { get; }
    }
}