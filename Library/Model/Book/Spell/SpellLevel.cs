using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book.Spell
{
    [Table]
    public class SpellLevel : ISpellLevel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public long Zeon { get; set; }
        public long IntellectRequirement { get; set; }
        public string Effect { get; set; }
        public long Maintenance { get; set; }
    }
}