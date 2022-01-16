﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Model.Anima;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Anima.Book.Spell;
using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Shared;

namespace Library.Model
{
    public class CoreSpellBookFilter : ICoreSpellBookFilter
    {
        public ValueTask<bool> BySchool(string[] filter, ICoreSpellBook spellBook)
        {
            return filter.Any()
                ? new ValueTask<bool>(filter.Any(school =>string.Equals(school, spellBook.School, StringComparison.OrdinalIgnoreCase)))
                : new ValueTask<bool>(true);
        }

        public ValueTask<ICoreSpellBook> BySpell(string[] filter, ICoreSpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ICoreSpell>();
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

            return new ValueTask<ICoreSpellBook>(spellBook);
        }

        public ValueTask<ICoreSpellBook> ByTag(string[] filter, ICoreSpellBook spellBook)
        {
            if (filter.Any())
            {
                var removeList = new List<ICoreSpell>();
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

            return new ValueTask<ICoreSpellBook>(spellBook);
        }

        public ValueTask<ICoreSpellBook> BySpecial(string[] filters, ICoreSpellBook spellBook)
        {
            if (filters.Any())
            {
                var containsList = new HashSet<ICoreSpell>();
                foreach (var filter in filters)
                {
                    foreach (var spell in spellBook.Spells)
                    {
                        var containsSpecial = filter.Equals(spell.MaintenanceDuration.ToString(), StringComparison.OrdinalIgnoreCase);
                        if (containsSpecial)
                        {
                            containsList.Add(spell);
                        }
                    }
                }

                var removeList = spellBook.Spells
                    .Where(spell => !containsList.Contains(spell))
                    .ToList();

                foreach (var spell in removeList)
                {
                    spellBook.Spells.Remove(spell);
                }
            }

            return new ValueTask<ICoreSpellBook>(spellBook);
        }
    }
}