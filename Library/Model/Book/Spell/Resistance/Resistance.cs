using Interfaces.Model.Book.Spell;
using Interfaces.Model.Enum;

namespace Library.Model.Book.Spell.Resistance
{
    public class Resistance : IResistance
    {
        public ResistanceType Type { get; set; }
        public long Value { get; set; }
    }
}