using System.Text.Json.Serialization;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book.Spell.Resistance
{
    [Table]
    public class Resistance : IResistance 
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => $"{Type}{Value}";

        public ResistanceType Type { get; set; }
        public long Value { get; set; }
    }
}