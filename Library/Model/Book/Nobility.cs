using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book
{
    [Table]
    public class Nobility : INobility
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Identification.Nobility;

        public string Name { get; set; }
        public string School { get; set; }

        [DbObjectCollection]
        public ICollection<IArcanaSpell> Spells { get; set; }
    }
}