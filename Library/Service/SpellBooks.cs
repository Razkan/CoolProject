using Interfaces.Model.Book;
using Interfaces.Model.Enum;
using Library.Model.Book;
using Library.Model.Book.Spell;
using Library.Model.Book.Spell.Resistance;

namespace Library.Service
{
    public class SpellBooks
    {
        public static ISpellBook GetBookOfLight()
        {
            return new BookOfLight
            {
                Name = "Book of Light",
                School = "Light",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Create Light",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 20,
                        Effect = "Creates light in a radius of 15 feet",
                        AddedEffect = "15 feet radius",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (2)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfDarkness()
        {
            return new BookOfDarkness
            {
                Name = "Book of Darkness",
                School = "Darkness",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Create Darkness",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 20,
                        Effect = "Completely darkens an area within a 15-foot radius. " +
                                 "Everything within the area is perceived as though on a dark and moonless night.",
                        AddedEffect = "15 feet radius,",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (2)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfCreation()
        {
            return new BookOfCreation
            {
                Name = "Book of Creation",
                School = "Creation",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Minor Creation",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "Creates a simple object with a Presence of no more than 25",
                        AddedEffect = "Creates one additional object",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfDestruction()
        {
            return new BookOfDestruction
            {
                Name = "Book of Destruction",
                School = "Destruction",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Fragility",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "This spell alters the solidity of an object, reducing its sturdiness and " +
                                 "making it easy to break. Anything affected automatically loses its Damage " +
                                 "Barrier; if the spell is cast on arms or armor, their Fortitude receives a reduction " +
                                 "of –2. This spell affects objects with a Presence of no more than 30",
                        AddedEffect = "+5 to the maximum Presence that can be affected and –1 " +
                                      "to Fortitude",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfAir()
        {
            return new BookOfAir
            {
                Name = "Book of Air",
                School = "Air",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Raise Wind",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "Raises wind up to a maximum of 10 miles per hour. " +
                                 "The spellcaster needs to be in the open or in an area likely to experience wind drafts. " +
                                 "Maximum wind draft width is 80 feet.",
                        AddedEffect = "+5 miles per hour and +15 feet wide.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfWater()
        {
            return new BookOfWater
            {
                Name = "Book of Water",
                School = "Water",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Spring",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "This spell draws forth any nearby underground current or stream, " +
                                 "causing a spring to flow from the spot designated by the caster. The spell " +
                                 "affects natural liquids within 300 feet of the character casting the spell, but it " +
                                 "can not overcome energy barriers",
                        AddedEffect = "+100 feet to radius.",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfFire()
        {
            return new BookOfFire
            {
                Name = "Book of Fire",
                School = "Fire",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Create Fire",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "This spell creates a fire with an intensity of 1. The flame is magical and " +
                                 "does not require any fuel. If placed upon flammable material, the material will " +
                                 "continue burn naturally even after the spell has ended.",
                        AddedEffect = "+1 fire intensity.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfEarth()
        {
            return new BookOfEarth
            {
                Name = "Book of Earth",
                School = "Earth",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Detect Minerals",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 20,
                        Effect = "he caster can detect a particular mineral’s location in a 30-foot " +
                                 "radius. The spell also gives an approximation of the size and purity of the " +
                                 "source. Energy based barriers can not be overcome",
                        AddedEffect = "+5 meters to radius.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Automatic,
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfEssence()
        {
            return new BookOfEssence
            {
                Name = "Book of Essence",
                School = "Essence",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Natural Affinity",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "This spell alters the essence of an individual, allowing him to bond with " +
                                 "with natural beings so that such beings recognize the individual as one of their " +
                                 "own. For instance, this spell could be used to gain wolf affinity, so that wolves " +
                                 "would recognize the character as an actual wolf. This spell can affect up to a " +
                                 "total 60 Presence",
                        AddedEffect = "+10 to the maximum Presence affected.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    }
                }
            };
        }

        public static ISpellBook GetBookOfIllusion()
        {
            return new BookOfIllusion
            {
                Name = "Book of Illusions",
                School = "Illusions",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Illusory Sound",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = @"This spell allows the caster to create any sound, including human
                                voices, in a 60-foot radius area. All subjects within the area of effect must
                                pass a MR check with a Difficulty of 100 to disbelieve the effect, though the
                                spellcaster may choose which specific characters hear the illusion.",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 100
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Illusory Smell",
                        Action = SpellAction.Active,
                        Level = 6,
                        Cost = 30,
                        Effect = @"This spell creates an illusory smell. It affects those subjects in a 60-foot
                                radius who fail a MR Check with a Difficulty of 100. The caster can choose
                                who will smell the illusory scent and who will not.
                                Added Effect: +30 feet to radius and +5 to MR Difficulty.",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 100
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Illusory Touch",
                        Action = SpellAction.Active,
                        Level = 10,
                        Cost = 30,
                        Effect = @"This spell can distort the touch or the taste of a specific element. The
                                caster decides the element’s new taste or feel, which is noticed by all within
                                a 60-foot radius who fail a MR Check with a Difficulty of 100. The caster can
                                choose who notices the illusion and who does not.",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 100
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Visual Illusion",
                        Action = SpellAction.Active,
                        Level = 12,
                        Cost = 40,
                        Effect = @"This spell creates a false image that can deceive the viewer. The image
                                    must remain static and have only a maximum mass of 5 square feet. The spell
                                    affects anyone who sees the image and fails a MR Check with a Difficulty of
                                    100. It is up to the caster to decide who will see the image and who will not.",
                        AddedEffect = "+5 square feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "Intelligence x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 100
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Detect Illusion",
                        Action = SpellAction.Active,
                        Level = 16,
                        Cost = 60,
                        Effect = @"This spell enables the spellcaster to sense the presence of all Illusions
                                    with a Zeonic Value of 80 or less in a 150-foot radius.",
                        AddedEffect = "+30 feet to radius and +10 to Zeonic Value.",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Detection,
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new Spell
                    {
                        Name = "Sweet Talk",
                        Action = SpellAction.Active,
                        Level = 20,
                        Cost = 50,
                        Effect = "This spell enhances the targeted individual’s charisma and personal " +
                                 "charm. The character receives a +50 bonus the Leadership and Persuasion " +
                                 "Secondary Abilities.",
                        AddedEffect = "+10 to Leadership and Persuasion.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Effect,
                        Resistances = new Resistance[]
                        {
                        },
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Alter Appearance",
                        Action = SpellAction.Active,
                        Level = 22,
                        Cost = 60,
                        Effect = "The spellcaster can change the appearance of an individual or object " +
                                 "into that of another of his choosing. This spell will only increase or decrease " +
                                 "the targeted individual’s Size and Appearance by two degrees. All subjects in " +
                                 "contact with the image can see through the illusion if they pass a MR Check " +
                                 "with a Difficulty of 120.Once a viewer is affected by an illusion, he only " +
                                 "receives a new Resistance Check when he has reason to doubt the identity or " +
                                 "appearance of the subject.",
                        AddedEffect = "+10 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Illusory Invisibility",
                        Action = SpellAction.Active,
                        Level = 26,
                        Cost = 60,
                        Effect = "This spell allows the caster to make any being or object vanish from " +
                                 "sight. He can affect any number of people, as long as the sum of their Presence " +
                                 "does not exceed 140. Only individuals who pass a MR Check with a Difficulty " +
                                 "of 120 can detect the presence of the invisible character through their sense " +
                                 "of vision.",
                        AddedEffect = "+5 to MR and +10 to the maximum Presence affected.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Mirror Image",
                        Action = SpellAction.Active,
                        Level = 30,
                        Cost = 80,
                        Effect = "This spell creates eight illusory copies of any given target. The caster " +
                                 "can not place these mirror images more than 15 feet apart from one another. " +
                                 "Acting as mirrors, they perform the same actions as the targeted individual. " +
                                 "Any images hit by an Energy damaging attack are immediately destroyed. " +
                                 "Seeing through this illusion requires a MR Check with a Difficulty of 120.",
                        AddedEffect = "+5 to MR and +2 images.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (8)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Total Illusion",
                        Action = SpellAction.Active,
                        Level = 32,
                        Cost = 80,
                        Effect = "This spell creates a complete illusion that deceives all five of a victim’s " +
                                 "senses. The caster can create any inanimate object with a volume not exceeding " +
                                 "5 square feet. The illusion can be destroyed by Energy damaging attacks. This " +
                                 "spell affects anyone able to see, hear, smell, or feel the illusion who fails a MR " +
                                 "Check with a Difficulty of 120.",
                        AddedEffect = "+5 square feet to volume and +5 to MR.",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (2)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Detection,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.PlayerDecide,
                            Tag.Area
                        }
                    },
                    new Spell
                    {
                        Name = "Confusion",
                        Action = SpellAction.Active,
                        Level = 36,
                        Cost = 50,
                        Effect = "This spell confounds all five senses of a single target. The " +
                                 "target must pass a MR Check with a Difficulty of 120 to resist " +
                                 "the spell. If he fails, he suffers a penalty equal to his Failure " +
                                 "Level to all of his perception-based Secondary Abilities. " +
                                 "Furthermore, if he fails by more than 40, the target also " +
                                 "suffers a –20 All Action Penalty due to dizziness. An " +
                                 "affected cannot make a new Check unless he increases " +
                                 "his Resistances.",
                        AddedEffect = "+5 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Spiritual,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Create Illusory Being",
                        Action = SpellAction.Active,
                        Level = 40,
                        Cost = 60,
                        Effect = "This spell creates a first-level illusory being. " +
                                 "The entity is fashioned according to the caster’s desires, " +
                                 "using the rules set forth in Chapter 26 for Beings Between " +
                                 "Worlds.However, the illusory being’s nature automatically " +
                                 "grants it the Physical Exemption ability. " +
                                 "Because the creature is not real, it can not inflict damage or affect " +
                                 "physical reality whatsoever.All non - Energy based attacks pass right " +
                                 "through it without damaging it in any way.This spell must be cast " +
                                 "upon a specific area not exceeding a radius of 60 feet.Those characters " +
                                 "entering the spell’s area of effect must pass a MR Check with a Difficulty of " +
                                 "120 to avoid it.Even though the spell is circumscribed to a specific zone, the " +
                                 "illusory creature can leave that area while chasing after a subject affected " +
                                 "by the spell.However, it remains unseen by anyone not previously inside the spell’s " +
                                 "area.Keep in mind that those subjects who pass the MR Check do not exist to the " +
                                 "illusory creature, and it will ignore them.Illusions may have a maximum of two " +
                                 "levels more than the caster.",
                        AddedEffect = "+5 to MR, +1 to the created being’s level and +5 feet to radius.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                    new Spell
                    {
                        Name = "Resistance to Illusions",
                        Action = SpellAction.Active,
                        Level = 42,
                        Cost = 80,
                        Effect = "This spell increases a subject’s MR against illusory effects. It grants a +30 " +
                                 "bonus to every MR Check made against an illusion spell. The effects of this spell " +
                                 "do not overlap, and subjects may be affected by it only once.",
                        AddedEffect = "+10 to MR against illusions.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (8)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Effect,
                        Tags = new[]
                        {
                            Tag.PlayerDecide
                        }
                    },
                    new Spell
                    {
                        Name = "Detect Lie",
                        Action = SpellAction.Active,
                        Level = 46,
                        Cost = 80,
                        Effect = "This spell automatically detects any lie told in the caster’s presence. " +
                                 "Every time a lie is deliberately told before him, the liar must make a MR or " +
                                 "PsR Check with a Difficulty of 120 to prevent the caster from finding out. Lies " +
                                 "unknowingly told are not detected by the spell.",
                        AddedEffect = "+5 to MR or PsR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (8)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            },
                            new Resistance
                            {
                                Type = ResistanceType.Psychic,
                                Value = 120
                            },
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new Spell
                    {
                        Name = "Ghostly Illusion",
                        Action = SpellAction.Active,
                        Level = 50,
                        Cost = 120,
                        Effect = "This spell creates one or several objects governed by the Ghostly " +
                                 "Spell rules. Any inanimate object the caster desires can be produced, " +
                                 "from a sword to a wall, provided that its theoretical Presence does not " +
                                 "exceed 60. A character or creature can avoid the spell and ignore the " +
                                 "illusion if he or it passes a MR Check with a Difficulty of 120. " +
                                 "Anyone can make another Check if he has reason to doubt the " +
                                 "reality of the object.",
                        AddedEffect = "+5 to the maximum Presence of the object " +
                                      "and +5 to the MR Difficulty.",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                }
            };
        }

        public static ISpellBook GetBookOfNecromancy()
        {
            return new BookOfNecromancy
            {
                Name = "Book of Necromancy",
                School = "Necromancy",
                Spells = new[]
                {
                    new Spell
                    {
                        Name = "Feel Death",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "The necromancer automatically detects any deaths occurring 300 feet " +
                                 "around him. This spell also reveals undead creatures if they fail a MR Check " +
                                 "with a Difficulty of 120.",
                        AddedEffect = "+80 feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Detection,
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 120
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    }
                }
            };
        }
    }
}