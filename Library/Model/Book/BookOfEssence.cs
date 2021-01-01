﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model.Book;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Db.Attribute;

namespace Library.Model.Book
{
    [Table]
    public class BookOfEssence : IBookOfEssence
    {
        [JsonIgnore]
        [PrimaryKey]
        public string Id => Identification.BookOfEssence;

        public string Name { get; set; }
        public string School { get; set; }

        [DbObjectCollection]
        public ICollection<ISpell> Spells { get; set; }
    }
}