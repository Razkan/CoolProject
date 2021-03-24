using Interfaces.Model.Book;
using Interfaces.Model.Enum;
using Library.Model.Book;
using Library.Model.Book.Spell;

namespace Library.Service
{
    public class ArcanaSpellBooks
    {
        public static IArcanaSpellBook GetNobility()
        {
            return new Nobility
            {
                Name = "Nobility",
                School = "Nobility",
                Spells = new[]
                {
                    new ArcanaSpell
                    {
                        Name = "Visage",
                        Action = SpellAction.Active,
                        Level = 4,
                        Effect = "This spell removes external imperfections on the target's face, covering " +
                                 "any defects with a soft layer of makeup and applying a slight supernatural healing " +
                                 "effect that eliminates any skin condition and enhances the character's color. He " +
                                 "gains a vital and healthy appearance.",
                        SpellLevel = new[]
                        {
                            new SpellLevel
                            {
                                Id = "Nobility_Basic",
                                Name = "Basic",
                                Zeon = 30,
                                IntellectRequirement = 5,
                                Effect = "The spell functions as described above.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Intermediate",
                                Name = "Intermediate",
                                Zeon = 50,
                                IntellectRequirement = 8,
                                Effect = "As Basic level, but the target gains 1 point of Appearance (up " +
                                         "to 9) and looks several years younger.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Advanced",
                                Name = "Advanced",
                                Zeon = 80,
                                IntellectRequirement = 10,
                                Effect = "As Intermediate level, but the spell increases Appearance by 2 " +
                                         "points (up to 10).",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Arcane",
                                Name = "Arcane",
                                Zeon = 120,
                                IntellectRequirement = 12,
                                Effect = "As Advanced level, but the spell increases Appearance by 3 points " +
                                         "(up to 10)",
                                Maintenance = 10
                            },
                        },
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Buff
                        }
                    },
                    new ArcanaSpell
                    {
                        Name = "Perfume",
                        Action = SpellAction.Active,
                        Level = 14,
                        Effect = "This spell adjusts the target's body odor, making it a fragrant, smooth, " +
                                 "and pleasant aroma and evoking a pleasant sensation in those within an area " +
                                 "determined by the level of the spell.",
                        SpellLevel = new[]
                        {
                            new SpellLevel
                            {
                                Id = "Nobility_Basic",
                                Name = "Basic",
                                Zeon = 40,
                                IntellectRequirement = 5,
                                Effect = "60 foot radius / The spell functions as described above.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Intermediate",
                                Name = "Intermediate",
                                Zeon = 60,
                                IntellectRequirement = 8,
                                Effect = "100 foot radius / As Basic level, but when the target makes a " +
                                         "Style check that might be influenced by his body odor, he can " +
                                         "increase the result of the check by one level.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Advanced",
                                Name = "Advanced",
                                Zeon = 90,
                                IntellectRequirement = 10,
                                Effect = "120 foot radius / As Intermediate level, but the spell increases " +
                                         "the result of the check by two levels.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Arcane",
                                Name = "Arcane",
                                Zeon = 120,
                                IntellectRequirement = 12,
                                Effect = "150 foot radius / As Advanced level, and anyone who smells the " +
                                         "parfume for more than 5 turns must pass a MR 100 check or fall " +
                                         "into a state of Fascination, becoming stupefied with pleasure and " +
                                         "more receptive to the target's words.",
                                Maintenance = 10
                            },
                        },
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect,
                            SpellType.Automatic
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Buff,
                            Tag.Area,
                            Tag.Target,
                            Tag.Single
                        }
                    },
                    new ArcanaSpell
                    {
                        Name = "Musa",
                        Action = SpellAction.Active,
                        Level = 24,
                        Effect = "This spell gives the caster the inspiration to make a masterful interpretation " +
                                 "of a traditional art form such as playing an instrument",
                        SpellLevel = new[]
                        {
                            new SpellLevel
                            {
                                Id = "Nobility_Basic",
                                Name = "Basic",
                                Zeon = 40,
                                IntellectRequirement = 5,
                                Effect = "",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Intermediate",
                                Name = "Intermediate",
                                Zeon = 60,
                                IntellectRequirement = 8,
                                Effect = "100 foot radius / As Basic level, but when the target makes a " +
                                         "Style check that might be influenced by his body odor, he can " +
                                         "increase the result of the check by one level.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Advanced",
                                Name = "Advanced",
                                Zeon = 90,
                                IntellectRequirement = 10,
                                Effect = "120 foot radius / As Intermediate level, but the spell increases " +
                                         "the result of the check by two levels.",
                                Maintenance = 5
                            },
                            new SpellLevel
                            {
                                Id = "Nobility_Arcane",
                                Name = "Arcane",
                                Zeon = 120,
                                IntellectRequirement = 12,
                                Effect = "150 foot radius / As Advanced level, and anyone who smells the " +
                                         "parfume for more than 5 turns must pass a MR 100 check or fall " +
                                         "into a state of Fascination, becoming stupefied with pleasure and " +
                                         "more receptive to the target's words.",
                                Maintenance = 10
                            },
                        },
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect,
                            SpellType.Automatic
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Buff,
                            Tag.Area,
                            Tag.Target,
                            Tag.Single
                        }
                    },
                }
            };
        }
    }
}