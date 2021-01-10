using Interfaces.Model.Book;
using Interfaces.Model.Enum;
using Library.Model.Book;
using Library.Model.Book.Spell;

namespace Library.Service
{
    public class SubPaths
    {
        public static ISubPath GetNobility()
        {
            return new Nobility
            {
                Name = "Nobility",
                School = "Nobility",
                Spells = new[]
                {
                    new SubPathSpell
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
                    }
                }
            };
        }
    }
}