﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book
{
    [Table]
    public class BookOfIllusion : IBookOfIllusion
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Identification.BookOfIllusion;

        public string Name { get; set; }
        public string School { get; set; }

        [DbObjectCollection]
        public ICollection<ICoreSpell> Spells { get; set; }
    }
}