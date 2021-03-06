﻿using System.Collections.Generic;
using Interfaces.Model.Book;
using Interfaces.Model.Book.Spell;

namespace Library.Model.Book
{
    public class BookOfEssence : IBookOfEssence
    {
        public string Name { get; set; }
        public string School { get; set; }
        public ICollection<ISpell> Spells { get; set; }
    }
}