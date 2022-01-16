using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book
{
    [Table]
    public class BookOfLight : IBookOfLight
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Identification.BookOfLight;

        public string Name { get; set; }
        public string School { get; set; }

        [DbObjectCollection]
        public ICollection<ICoreSpell> Spells { get; set; }
    }
}