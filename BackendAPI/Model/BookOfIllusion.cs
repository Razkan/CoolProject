using Interfaces.Model.Book;
using Interfaces.Model.Enum;
using Library.Model.Book;
using Library.Model.Book.Spell;
using Library.Model.Book.Spell.Resistance;

namespace BackendAPI.Model
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new MagicResistance
                            {
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new MagicResistance
                            {
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new MagicResistance
                            {
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Automatic,
                        Resistances = new[]
                        {
                            new MagicResistance
                            {
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Detection,
                        Tags = new[]
                        {
                            Tag.Self
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
                        ZeonAttribute = CharacterAttribute.Intelligence,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = SpellType.Detection,
                        Resistances = new []
                        {
                            new MagicResistance
                            {
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