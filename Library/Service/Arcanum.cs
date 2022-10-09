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
                    School = School.Matter,
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
                                    School = School.Fate,
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
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Detect Substance",
                            Level = 1,
                            Effect = "The mage chooses a number of substances or objects that fall " +
                            "under Matter’s purview equal to the spell’s Potency. As long " +
                            "as this spell is active, the subject is automatically aware of the " +
                            "presence and location of the chosen substance within the area " +
                            "of effect. The chosen substance can be as broad or as specific " +
                            "as the mage likes (“ferrous metal,” “stainless steel,” “a knife,” " +
                            "and “my hunting knife” are all valid options).",
                            Practice = Practice.Unveiling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Investigation,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = Array.Empty<IReachEffect>(),
                            SchoolEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = School.Time,
                                    Level = 1,
                                    Effect = "The subject can detect whether the chosen " +
                                             "substance has been in the area within an amount of time equal " +
                                             "to the spell’s Duration."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = School.Forces,
                                    Level = 1,
                                    Effect = "The subject can search for specific types of " +
                                             "electronic information, such as digital audio, photographs, or " +
                                             "text documents. Not only will the spell reveal which devices " +
                                             "have the chosen file type on board, if she’s actually using the " +
                                             "device the mage knows where on the device the files are stored."
                                },
                            },
                            Tags = new[]
                            {
                                Tag.Area,
                                Tag.Self,
                                Tag.Single
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Discern Composition",
                            Level = 1,
                            Effect = "The subject becomes aware of the precise composition of an " +
                                     "object: its weight and density, as well as the precise elements " +
                                     "that make it up.",
                            Practice = Practice.Knowing,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Investigation,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The subject also becomes aware of any objects " +
                                             "concealed within the object: a gold relic hidden in a secret " +
                                             "compartment in a stone statue, for example."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The subject instinctively knows the object’s structural weak point. " +
                                             "Attempts to damage the object reduce its " +
                                             "Durability by –1 per point of the spell’s Potency. This benefit " +
                                             "lasts until the object is destroyed or fully repaired."
                                }
                            },
                            SchoolEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = School.Space,
                                    Level = 2,
                                    Effect = "The subject is aware not only of what the " +
                                             "object is made of, but of precisely where the material came from " +
                                             "(e.g. where the ore was mined, where the tree that made the " +
                                             "board was felled, or where the circuit board was manufactured). " +
                                             "Casting this spell on a Supernal Artifact strikes the subject with " +
                                             "an overwhelming rush of images and symbols: Roll the Artifact’s " +
                                             "dot rating, contested by the subject’s Gnosis. If the Artifact " +
                                             "earns more successes, the subject gains the Shaken Condition. " +
                                             "Resolving the Condition grants an Arcane Beat."
                                }
                            },
                            Tags = new[]
                            {
                                Tag.Self,
                                Tag.Single,
                                Tag.Target
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Lodestone",
                            Level = 1,
                            Effect = "The mage chooses a substance or type of object. As long as the " +
                                     "spell remains active, those objects within the spell’s Area are drawn " +
                                     "to the spell’s subject: Dropped coins bounce toward her, water flows " +
                                     "in her direction as long as she’s standing downstream, and so on. " +
                                     "Unless the object is capable of moving under its own power, this " +
                                     "spell can only nudge the object when an external force is imparted " +
                                     "on it: a ball might roll across the floor, but a heavy book won’t fly " +
                                     "off a table into the subject’s hand. (It might, however, tip and fall " +
                                     "off a shelf if it was precariously balanced to begin with.) " +
                                     "Alternately, the mage can repel objects from the subject in the " +
                                     "same fashion. This spell isn’t strong enough to deflect a weapon " +
                                     "swung or fired with intent to harm, but it can certainly keep " +
                                     "the mage dry in a rainstorm or keep a cloud of tear gas at bay.",
                            Practice = Practice.Compelling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Larceny,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = Array.Empty<IReachEffect>(),
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Area,
                                Tag.Self
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Remote Control",
                            Level = 1,
                            Effect = "With the commanding power of Stygia, the subject can control " +
                                     "any mechanical object, making it fulfill its function. She might " +
                                     "flip a light switch, cause an industrial press to slam downward, " +
                                     "or shift a car into gear. Anything that’s within the bounds of a " +
                                     "single instant action, and which the subject device is capable of " +
                                     "performing, is fair game. Should the action require a Skill roll, " +
                                     "treat the spell’s Potency as its successes.",
                            Practice = Practice.Compelling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Drive,
                                RoteSkills.Intimidate
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The subject can perform more complex tasks " +
                                             "while controlling the object, including extended actions or " +
                                             "maintaining continuous control of the object as long as the " +
                                             "spell’s Duration lasts."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Single,
                                Tag.Crowd_Control
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Alchemist’s Touch",
                            Level = 2,
                            Effect = "Draped in the leaden shrouds of Stygia, " +
                                     "the subject may handle even the most dangerous of substances without fear. " +
                                     "When the spell is cast, the mage chooses a particular form of matter: " +
                                     "The subject is largely immune to its deleterious effects. The " +
                                     "material cannot inflict bashing damage on her at all, and she " +
                                     "reduces the damage from lethal sources of harm by the spell’s " +
                                     "Potency. The spell has no effect on aggravated damage. " +
                                     "This spell only protects the mage from harm that comes due " +
                                     "to an intrinsic property of the material. The damage from a gun " +
                                     "or a sword, for example, comes from the force behind the impact " +
                                     "and thus isn’t reduced by this spell.However, a mage under the " +
                                     "protection of this spell can handle radioactive or caustic substances " +
                                     "or walk through a cloud of chlorine gas with no ill effects",
                            Practice = Practice.Shielding,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Survival,
                                RoteSkills.Persuasion
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The mage chooses another form of matter the " +
                                             "spell protects against."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 2,
                                    Effect = "The mage is immune to bashing and lethal damage " +
                                             "from the material, and reduces any aggravated damage by the " +
                                             "spell’s Potency."
                                }
                            },
                            SchoolEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = School.Forces,
                                    Level = 2,
                                    Effect = "The subject is protected from extreme temperatures " +
                                             "caused by the substance’s state. She can walk across " +
                                             "lava, scoop up a handful of molten steel without being burned, " +
                                             "or dip a finger in liquid nitrogen without it freezing."
                                }
                            },
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Buff,
                                Tag.Shield,
                                Tag.Protection,
                                Tag.Other
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Find the Balance",
                            Level = 2,
                            Effect = "Those initiated into the Stygian Mysteries know that understanding " +
                                     "a tool is only the first step toward perfecting it. By subtly " +
                                     "manipulating the density and purity of a tool, the mage improves " +
                                     "its balance and heft. The tool grants its user the 9-Again quality " +
                                     "for the Duration of the spell, so long as it’s a tool that can benefit " +
                                     "from balance or weight distribution.",
                            Practice = Practice.Ruling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Persuasion,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The tool grants the 8-Again quality instead."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Buff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Hidden Hoard",
                            Level = 2,
                            Effect = "This spell renders Matter difficult to detect. It isn’t invisibility, " +
                                     "precisely; rather, the spell veils the subject’s connection to the " +
                                     "Supernal truths, making it seem insignificant and beneath notice. " +
                                     "Mundane attempts to detect the subject fail automatically. " +
                                     "Spells and powers that would detect the veiled object are subject " +
                                     "to a Clash of Wills.",
                            Practice = Practice.Veiling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Larceny,
                                RoteSkills.Occult,
                                RoteSkills.Subterfuge
                            },
                            Withstand = Withstand.None,
                            ReachEffects = Array.Empty<IReachEffect>(),
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Debuff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Machine Invisibility",
                            Level = 2,
                            Effect = "By means of this spell, the mage blinds the eyes and ears of " +
                                     "inert matter to her subject’s presence: cameras refuse to see " +
                                     "her, microphones refuse to hear her voice, and so on. " +
                                     "Supernatural objects (such as remote-viewing Artifacts or perhaps a " +
                                     "ghost-haunted camera) provoke a Clash of Wills.",
                            Practice = Practice.Veiling,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Larceny,
                                RoteSkills.Science,
                                RoteSkills.Stealth
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "This spell also applies to unliving constructs animated with magic, " +
                                             "including zombies and golems. Such beings " +
                                             "always provoke a Clash of Wills."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Buff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Shaping",
                            Level = 2,
                            Effect = "Liquids, gases, and amorphous solids are the mage’s playthings " +
                                     "with this spell. She can shape them into any form she desires, " +
                                     "manipulating them in defiance of gravity, for as long as the " +
                                     "spell lasts.This spell cannot change the state of matter(e.g. " +
                                     "from solid to liquid), but substances that have been temporarily " +
                                     "transformed into shapeable states by magic may be affected. " +
                                     "Particularly intricate shapes may require a reflexive Wits + Crafts " +
                                     "roll, at the Storyteller’s discretion.",
                            Practice = Practice.Knowing,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Expression,
                                RoteSkills.Persuasion
                            },
                            Withstand = Withstand.Durability,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The mage can alter the shape of solid substances " +
                                             "as well. If used to warp a tool or weapon, each point of Potency " +
                                             "reduces the subject’s equipment bonus or damage by –1. If the " +
                                             "equipment bonus or damage is reduced to 0, the object is useless."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = " If the mage is creating or repairing an object using this spell, " +
                                             "reduce the number of successes required on the extended " +
                                             "action by one per point of Potency. This can’t reduce " +
                                             "the number of required successes below one."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 2,
                                    Effect = "The mage can create an appropriate Environmental " +
                                             "Tilt, such as Earthquake, Flooded, or Howling Winds."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Self,
                                Tag.Target
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Aegis",
                            Level = 3,
                            Effect = "By adjusting the properties of matter, the mage may make silk " +
                                     "shirts bullet-proof, or tear through bulky riot suits with her bare " +
                                     "hands. The spell is cast upon a wearable object (giving living " +
                                     "beings Armor is a function of Life). For each level of Potency, " +
                                     "the player chooses one of the following effects:".Newline() +
                                     "Raise or lower ballistic Armor rating by 1".Newline() +
                                     "Raise or lower general Armor rating by 1".Newline() +
                                     "Raise or lower Defense penalty by 1",
                            Practice = Practice.Weaving,
                            PrimaryFactor = PrimaryFactor.Duration,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Athletics,
                                RoteSkills.Crafts,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The armor becomes immune to the Armor-Piercing effect."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Shield,
                                Tag.Protection,
                                Tag.Debuff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Alter Conductivity",
                            Level = 3,
                            Effect = "With this spell, the mage alters a subject’s base properties, " +
                                     "changing the manner in which it conducts electricity. This spell " +
                                     "can automatically shut down any electrical device whose power isn’t " +
                                     "great enough to inflict damage, or it can increase or decrease the " +
                                     "amount of electricity that can flow through the object. For each level " +
                                     "of Potency, the spell allows the object to conduct two points worth " +
                                     "of electrical damage, or reduces electrical damage by two. The object " +
                                     "must still be in contact with an appropriate source of electricity to " +
                                     "deal this damage; even a Potency 6 spell won’t let the power from " +
                                     "a household wall outlet inflict more than four points of bashing " +
                                     "damage (see Electricity on p. 224). Reducing electrical damage to " +
                                     "zero also shuts electrical devices down — for example, completely " +
                                     "snuffing a subway rail’s conductivity shuts the trains down.",
                            Practice = Practice.Ruling,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Computers,
                                RoteSkills.Science,
                                RoteSkills.Subterfuge
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The mage can alter the subject’s ability to transmit " +
                                             "other forms of energy, such as heat, sound, or even light. " +
                                             "Each additional form of energy is an extra Reach."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Buff,
                                Tag.Debuff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Alter Integrity",
                            Level = 3,
                            Effect = "By rotating an object’s resonance into or out of alignment with " +
                                     "Stygian truths, the mage can strengthen or weaken its material. " +
                                     "Every level of Potency either increases or decreases the object’s " +
                                     "Durability by 1. This does not increase the object’s Structure, " +
                                     "but see below.",
                            Practice = Practice.FrayingOrPerfecting,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Medicine,
                                RoteSkills.Subterfuge
                            },
                            Withstand = Withstand.Durability,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "In lieu of increasing Durability, one level of Potency may be " +
                                             "“spent” to give the object 2 additional points of " +
                                             "Structure. If the spell wears off and the object has taken more " +
                                             "damage than it has Structure, it crumbles to dust."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 2,
                                    Effect = "The effect is Lasting."
                                },
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Crucible",
                            Level = 3,
                            Effect = "With this spell, an object takes on a glimmer of Supernal " +
                                     "purity. If its primary purpose is as a tool, it grants 8-Again " +
                                     "a number of rolls equal to the spell’s Potency. Valuable objects, " +
                                     "such as gold or diamonds, become incredibly pure and beautiful. Add the spell’s Potency to the object’s Availability rating " +
                                     "to determine its increased value. This spell cannot increase an " +
                                     "object’s Availability to more than twice its original rating.",
                            Practice = Practice.Perfecting,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Occult,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "For one point of Mana, the object grants the rote " +
                                             "action quality on a number of rolls equal to the spell’s Potency. " +
                                             "As long as the spell’s Duration lasts, its wielder may spend one " +
                                             "point of Mana at any time to “recharge” this effect, granting " +
                                             "the rote action quality on an additional number of rolls equal " +
                                             "to the spell’s Potency."
                                },
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "The spell may increase the object’s Availability to " +
                                             "three times its original rating."
                                },
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Target,
                                Tag.Enchant,
                                Tag.Buff
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Nigredo and Albedo",
                            Level = 3,
                            Effect = "All matter contains within itself the Supernal Truth of its own " +
                                     "perfection — or its annihilation. This spell allows the mage to " +
                                     "repair or destroy objects, restoring lost Structure or inflicting " +
                                     "damage equal to the spell’s Potency.",
                            Practice = Practice.FrayingOrPerfecting,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Brawl,
                                RoteSkills.Medicine
                            },
                            Withstand = Withstand.None,
                            ReachEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    Reach = 1,
                                    Effect = "When inflicting damage, ignore the object’s Durability."
                                }
                            },
                            SchoolEffects = Array.Empty<ISchoolEffect>(),
                            Tags = new[]
                            {
                                Tag.Buff,
                                Tag.Debuff,
                                Tag.Target,
                                Tag.Defensive,
                                Tag.Offensive
                            }
                        },
                        new
                        {
                            Id = Identification.Generate(),
                            Name = "Shrink and Grow",
                            Level = 3,
                            Effect = "By means of this spell, the mage may bring an object’s Supernal reflection closer to the world or push it farther away. This " +
                                     "in turn causes the Supernal to cast a larger or smaller shadow " +
                                     "into the Fallen World, effectively making the object grow or " +
                                     "shrink. Each level of Potency either adds or subtracts one from " +
                                     "the subject’s Size. Size 0 objects can be shrunk down to roughly " +
                                     "the size of a dime.",
                            Practice = Practice.Weaving,
                            PrimaryFactor = PrimaryFactor.Potency,
                            SuggestedRoteSkills = new []
                            {
                                RoteSkills.Crafts,
                                RoteSkills.Expression,
                                RoteSkills.Science
                            },
                            Withstand = Withstand.Durability,
                            ReachEffects = Array.Empty<IReachEffect>(),
                            SchoolEffects = new []
                            {
                                new
                                {
                                    Id = Identification.Generate(),
                                    School = School.Life,
                                    Level = 3,
                                    Effect = "The spell can affect living subjects. Unwilling " +
                                             "subjects may Withstand with Stamina."
                                }
                            },
                            Tags = new[]
                            {
                                Tag.Buff,
                                Tag.Debuff,
                                Tag.Target
                            }
                        },
                        //new
                        //{
                        //    Id = Identification.Generate(),
                        //    Name = "",
                        //    Level = 3,
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
                        //    ReachEffects = Array.Empty<IReachEffect>(),
                        //    SchoolEffects = Array.Empty<ISchoolEffect>(),
                        //    Tags = new[]
                        //    {
                        //        Tag.Area
                        //    }
                        //},
                        //new
                        //{
                        //    Id = Identification.Generate(),
                        //    Name = "",
                        //    Level = 3,
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

    public static class HTMLExtension
    {
        public static string Newline(this string str)
        {
            return str + "\n";
        }
    }
}