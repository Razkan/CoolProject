using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Book;
using Interfaces.Model.Book.Spell;
using Interfaces.Model.Enum;

namespace Library.Model
{
    public class SpellBookFilter : ISpellBookFilter
    {
        public ValueTask<bool> BySchool(string[] filter, ISpellBook spellBook)
        {
            return filter.Any()
                ? new ValueTask<bool>(filter.Any(school =>string.Equals(school, spellBook.School, StringComparison.OrdinalIgnoreCase)))
                : new ValueTask<bool>(true);
        }

        public ValueTask<ISpellBook> BySpell(string[] filter, ISpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ISpell>();
                foreach (var spell in spellBook.Spells)
                {
                    var containsWord = false;
                    if (spell.Tags != null && spell.Tags.Any())
                    {
                        foreach (var word in filter)
                        {
                            if (spell.Name.Contains(word, StringComparison.OrdinalIgnoreCase))
                            {
                                containsWord = true;
                            }
                        }
                    }

                    if (!containsWord)
                    {
                        removeList.Add(spell);
                    }
                }

                foreach (var spell in removeList)
                {
                    spellBook.Spells.Remove(spell);
                }
            }

            return new ValueTask<ISpellBook>(spellBook);
        }

        public ValueTask<ISpellBook> ByTag(string[] filter, ISpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ISpell>();
                var enumTags = filter.Select(Enum.Parse<Tag>).ToArray();
                foreach (var spell in spellBook.Spells)
                {
                    var containsTag = false;
                    if (spell.Tags != null && spell.Tags.Any())
                    {
                        foreach (var tag in enumTags)
                        {
                            if (spell.Tags.Contains(tag))
                            {
                                containsTag = true;
                            }
                        }
                    }

                    if (!containsTag)
                    {
                        removeList.Add(spell);
                    }
                }

                foreach (var spell in removeList)
                {
                    spellBook.Spells.Remove(spell);
                }
            }

            return new ValueTask<ISpellBook>(spellBook);
        }

        public ValueTask<ISpellBook> BySpecial(string[] filter, ISpellBook spellBook)
        {
            return new ValueTask<ISpellBook>(spellBook);
        }
    }
}