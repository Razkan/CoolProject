using System.Collections.Generic;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Enum;

namespace Library.Model.Book.Spell
{
    public class Spell : ISpell
    {
        public string Name { get; set; }
        public SpellAction Action { get; set; }
        public long Level { get; set; }
        public long Cost { get; set; }
        public string Effect { get; set; }
        public string AddedEffect { get; set; }
        public string MaximumZeon { get; set; }
        public CharacterAttribute ZeonAttribute { get; set; }
        public string Maintenance { get; set; }
        public MaintenanceDuration MaintenanceDuration { get; set; }
        public SpellType Type { get; set; }
        public IEnumerable<IResistance> Resistances { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}