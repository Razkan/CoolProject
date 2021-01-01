using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Book;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book
{
    [Table]
    public class BookOfNecromancy : IBookOfNecromancy
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Identification.BookOfNecromancy;

        public string Name { get; set; }
        public string School { get; set; }

        [DbObjectCollection]
        public ICollection<ISpell> Spells { get; set; }
    }
}