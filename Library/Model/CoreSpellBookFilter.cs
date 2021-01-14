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
    public class CoreSpellBookFilter : ICoreSpellBookFilter
    {
        public ValueTask<bool> BySchool(string[] filter, ICoreSpellBook coreSpellBook)
        {
            return filter.Any()
                ? new ValueTask<bool>(filter.Any(school =>string.Equals(school, coreSpellBook.School, StringComparison.OrdinalIgnoreCase)))
                : new ValueTask<bool>(true);
        }

        public ValueTask<ICoreSpellBook> BySpell(string[] filter, ICoreSpellBook coreSpellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ICoreSpell>();
                foreach (var spell in coreSpellBook.Spells)
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
                    coreSpellBook.Spells.Remove(spell);
                }
            }

            return new ValueTask<ICoreSpellBook>(coreSpellBook);
        }

        public ValueTask<ICoreSpellBook> ByTag(string[] filter, ICoreSpellBook coreSpellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ICoreSpell>();
                var enumTags = filter.Select(Enum.Parse<Tag>).ToArray();
                foreach (var spell in coreSpellBook.Spells)
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
                    coreSpellBook.Spells.Remove(spell);
                }
            }

            return new ValueTask<ICoreSpellBook>(coreSpellBook);
        }

        public ValueTask<ICoreSpellBook> BySpecial(string[] filter, ICoreSpellBook coreSpellBook)
        {
            return new ValueTask<ICoreSpellBook>(coreSpellBook);
        }
    }
}