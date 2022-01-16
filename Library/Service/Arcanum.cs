using System;
using Interfaces.Model.Anima.Book;
using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Mage.Arcanum.Spell;
using Interfaces.Model.Mage.Enum;
using Interfaces.Model.Shared;
using Library.Emit;
using Library.Model.Book;

namespace Library.Service
{
    public class Arcanum
    {
        public static IArcanum GetMatter()
        {
            return InterfaceBuilder
                .New()
                .AddValues(new
                {
                    Id = Identification.Generate(),
                    Name = "Matter",
                    School = "Matter",
                    Spells = new object[]
                    {
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Craftsman's Eye",
                            Level = 1,
                            Effect = "Under the craftsman’s eye, no tool is mysterious. By studying an " +
                                      "object for one turn, the subject gains a complete understanding of " +
                                      "the object’s intended function. From a tool as simple as a hammer " +
                                      "to an intricate puzzle box, the item’s intended purpose is plain to " +
                                      "see. If the object has no purpose (for example, a simple rock), the " +
                                      "spell reveals that too. Likewise, if something prevents the object " +
                                      "from fulfilling its purpose (for example, a car missing its spark " +
                                      "plugs can’t drive), the spell reveals the nature of the problem.",
                            Practice = Practice.Knowing,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Investigation,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            Reaches = new[]
                            {
                                SpellType.Effect
                            },
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The subject’s senses expand to an understanding " +
                                              "of how to use the examined object. Not only does this reveal " +
                                              "things like the combination to a safe or the solution to a puzzle, it " +
                                              "grants the subject 8-Again on all actions made using the studied " +
                                              "object for its intended purpose.Only the most recently studied " +
                                              "object gains this benefit."
                                },                                
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 2,
                                    Effect = "As above, plus the spell reveals all potential uses " +
                                              "of an object, fanned out in a vast array of Supernal symbols " +
                                              "around the object. Focusing on a particular use might require " +
                                              "a reflexive Wits + Composure roll for especially complex items"
                                }
                            },
                            SchoolEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = "Fate",
                                    Level = 1,
                                    Effect = "The mage names a particular task when casting the spell " +
                                              "(e.g. “get leverage on Carruthers,” “translate the Codex Afire”). " +
                                              "Any object that might help with that task seem to loom " +
                                              "larger, to be more physically present, and are immediately obvious " +
                                              "to the subject as soon as she lays eyes on them."
                                }
                            },
                            Tags = new[]
                            {
                                Tag.Self,
                                Tag.Buff,
                                Tag.Single
                            }
                        },
                        //new
                        //{
                        //    Id = Identification.Generate(),
                        //    Name = "",
                        //    Level = 1,
                        //    Effect = "",
                        //    Practice = Practice.Knowing,
                        //    PrimaryFactor = PrimaryFactor.Duration,
                        //    SuggestedRoteSkills = new []
                        //    {
                        //        RoteSkills.Crafts,
                        //        RoteSkills.Investigation,
                        //        RoteSkills.Science
                        //    },
                        //    Withstand = Withstand.None,
                        //    Reaches = new[]
                        //    {
                        //        SpellType.Effect
                        //    },
                        //    ReachEffects = Array.Empty<IReachEffect>(),
                        //    SchoolEffects = Array.Empty<ISchoolEffect>(),
                        //    Tags = new[]
                        //    {
                        //        Tag.Area
                        //    }
                        //},
                    }
                }).Build<IArcanum>();
        }
    }
}