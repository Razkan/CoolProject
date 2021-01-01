using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Enum;

namespace Library.Model.Book.Spell
{
    [Table]
    public class Spell : ISpell
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Name;

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

        [DbObjectCollection]
        public IEnumerable<IResistance> Resistances { get; set; }

        [DbPrimitiveCollection]
        public IEnumerable<Tag> Tags { get; set; }
    }
}