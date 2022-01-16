using System.Collections.Generic;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Shared;

namespace Library.Model.Book.Spell
{
    [Table]
    public class ArcanaSpell : IArcanaSpell
    {
        public string Id => Name;

        public string Name { get; set; }
        public SpellAction Action { get; set; }
        public long Level { get; set; }
        public string Effect { get; set; }
        
        public MaintenanceDuration MaintenanceDuration { get; set; }

        [DbObjectCollection]
        public IEnumerable<ISpellLevel> SpellLevel { get; set; }

        [DbPrimitiveCollection]
        public IEnumerable<SpellType> Type { get; set; }

        [DbObjectCollection]
        public IEnumerable<IResistance> Resistances { get; set; }

        [DbPrimitiveCollection]
        public IEnumerable<Tag> Tags { get; set; }
    }
}