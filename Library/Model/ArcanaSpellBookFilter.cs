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
    public class ArcanaSpellBookFilter : IArcanaSpellBookFilter
    {
        public ValueTask<bool> BySchool(string[] filter, IArcanaSpellBook spellBook)
        {
            return filter.Any()
                ? new ValueTask<bool>(filter.Any(school =>string.Equals(school, spellBook.School, StringComparison.OrdinalIgnoreCase)))
                : new ValueTask<bool>(true);
        }

        public ValueTask<IArcanaSpellBook> BySpell(string[] filter, IArcanaSpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<IArcanaSpell>();
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

            return new ValueTask<IArcanaSpellBook>(spellBook);
        }

        public ValueTask<IArcanaSpellBook> ByTag(string[] filter, IArcanaSpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<IArcanaSpell>();
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

            return new ValueTask<IArcanaSpellBook>(spellBook);
        }

        public ValueTask<IArcanaSpellBook> BySpecial(string[] filter, IArcanaSpellBook spellBook)
        {
            return new ValueTask<IArcanaSpellBook>(spellBook);
        }
    }
}