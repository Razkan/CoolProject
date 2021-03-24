using Interfaces.Model.Book;
using Interfaces.Model.Enum;
using Library.Emit;
using Library.Model.Book;
using Library.Model.Book.Spell;
using Library.Model.Book.Spell.Resistance;

namespace Library.Service
{
    public class CoreSpellBooks
    {
        public static ICoreSpellBook GetBookOfLight()
        {
            return new BookOfLight
            {
                Name = "Book of Light",
                School = "Light",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Induce Calm",
                        Action = SpellAction.Active,
                        Level = 6,
                        Cost = 40,
                        Effect = "Calms individuals feeling fear or hatred within 50 feet " +
                                 "of the caster. Makes any Fear, Terror, or Anger States disappear, " +
                                 "even if of supernatural origin. It does not prevent violent actions " +
                                 "deliberately done in cold blood. The MR or PsR Check to " +
                                 "overcome this spell has a Difficulty of 80",
                        AddedEffect = "+30 feet to radius and +5 to MR or PsR Difficulty",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 80
                            },
                            new Resistance
                            {
                                Type = ResistanceType.Psychic,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Blinding Flash",
                        Action = SpellAction.Active,
                        Level = 8,
                        Cost = 50,
                        Effect = "Causes a sudden flash of light for a radius of 50 feet. " +
                                 "It blinds anyone looking at it when it goes off for as many " +
                                 "combat turns as he fails the MR check by, divided by 10.It is " +
                                 "not possible to designate specific targets within the flash, and " +
                                 "everyone except the caster is equally affected. Characters can " +
                                 "resist this spell by passing a PhR Check with a Difficulty of 140. " +
                                 "If someone is actively avoiding looking at the flash, the PhR Check " +
                                 "Difficulty is 80",
                        AddedEffect = "+15 feet to radius",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Physical,
                                Value = 140
                            },
                            new Resistance
                            {
                                Type = ResistanceType.Physical,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Shield of Light",
                        Action = SpellAction.Passive,
                        Level = 10,
                        Cost = 50,
                        Effect = "Forms a barrier of Energy that protects the caster from " +
                                 "any source of attack. The shield can absorb up to 300 points before " +
                                 "breaking, but is only damaged by supernatural attacks. Impacts based " +
                                 "on Darkness cause double damage",
                        AddedEffect = "+100 Resistance Points",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Defense
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Perceive",
                        Action = SpellAction.Active,
                        Level = 12,
                        Cost = 50,
                        Effect = "This spell improves the perception of the caster, increasing " +
                                 "his secondary abilities of Notice and Search by +50. It also " +
                                 "increases his Magical Appraisal by the same amount, but only " +
                                 "for the purpose of detecting or measuring the magic potency of " +
                                 "something or someone, not to hide it",
                        AddedEffect = "+10 to Notice, Search and Magical Appraisal",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Armor of Light",
                        Action = SpellAction.Active,
                        Level = 16,
                        Cost = 60,
                        Effect = "Forms a mystical armor with AT 2 against Energy-based Attacks, and " +
                                 "an AT of 1 against all others. Although it counts as armor, it does not count as " +
                                 "an additional layer of armor for purposes of penalties to Initiative.",
                        AddedEffect = "+1 to the AT",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Banish Shadows",
                        Action = SpellAction.Active,
                        Level = 18,
                        Cost = 60,
                        Effect = "Destroys shadows within a radius of 10 meters. Any darkness " +
                                 "based creatures within the radius must pass a MR Check with a Difficulty " +
                                 "of 120, or lose the double their Failure level in Life Points (Damage " +
                                 "Resistance creatures increases this amount by its Damage Resistance " +
                                 "multiple). As long as the spell is maintained over the creatures, they " +
                                 "must do a new MR Check each combat turn",
                        AddedEffect = "+20 meters to radius and +10 to the MR Difficulty",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Spiritual,
                            SpellType.Effect
                        },
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
                    new CoreSpell
                    {
                        Name = "Detect Negative Emotions",
                        Action = SpellAction.Active,
                        Level = 20,
                        Cost = 50,
                        Effect = "Detects any negative sentiments such as hatred, fear, or " +
                                 "anger within 10 meters of the caster. It also senses creatures based " +
                                 "on such emotions. Resisting the spell requires beating a MR Check " +
                                 "with a Difficulty of 80",
                        AddedEffect = "+20 meters to radius and +10 to the MR Difficulty",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Detection
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Light Beam",
                        Action = SpellAction.Active,
                        Level = 22,
                        Cost = 50,
                        Effect = "Projects a beam of Light based magical energy. Light Beam " +
                                 "is an Energy Attack Type with a Base Damage of 60",
                        AddedEffect = "+5 to Base Damage",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Attack
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Hologram",
                        Action = SpellAction.Active,
                        Level = 26,
                        Cost = 40,
                        Effect = "Creates an immaterial luminous form with a maximum size of " +
                                 "three square feet. The caster can give the hologram the appearance he " +
                                 "desires, making it very difficult to tell it from something real. If he creates " +
                                 "a creature, it can perform any inhuman action the caster wishes, but will " +
                                 "mimic the physical abilities of the caster. If, for example, the hologram is used " +
                                 "to simulate an attack, it uses the combat ability of the caster.The hologram cannot " +
                                 "touch anyone nor be touched, but if it receives any damage based on Energy, it " +
                                 "disappears.To detect that the hologram is not real, it is necessary to beat a Notice " +
                                 "check against a difficulty of Almost Impossible, or Search against Very Difficult",
                        AddedEffect = "+3 square feet to maximum size",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (4)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Bonds of Light",
                        Action = SpellAction.Active,
                        Level = 28,
                        Cost = 60,
                        Effect = "It cast bonds of light that hold the designated target immobile. An " +
                                 "attack is made using the rules for Trapping, although the caster suffers no " +
                                 "penalty to his Ability for performing this maneuver.The bonds use a Strength " +
                                 "of 8 for any Check. If anyone tries to help free the person Trapped, the Bonds " +
                                 "of Light are treated as an Energy weapon with a Fortitude of 20",
                        AddedEffect = "+1 to Strength for all checks",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Attack
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Control Light",
                        Action = SpellAction.Active,
                        Level = 30,
                        Cost = 50,
                        Effect = "Modifies and controls the form, color, or intensity of light in a 60-" +
                                 "foot radius. If cast at Light-based beings, they must pass a MR Check with a " +
                                 "Difficulty of 80 or they will fall under the control of the caster. A creature can " +
                                 "only repeat the check if it is ordered to do something against its nature",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Spiritual,
                            SpellType.Effect
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Detect Life",
                        Action = SpellAction.Active,
                        Level = 32,
                        Cost = 60,
                        Effect = "Detects any life-form within 80 feet. The spell only detects the number " +
                                 "of life-forms and their exact location. Resisting the spell requires beating a MR " +
                                 "Check with a Difficulty of 140",
                        AddedEffect = "+30 feet to radius and +10 to MR Difficulty",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Detection
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 140
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Spy of Light",
                        Action = SpellAction.Active,
                        Level = 36,
                        Cost = 100,
                        Effect = "Creates a small light of energy that moves as wished by the caster, " +
                                 "with a Flight Value of 14, for a maximum distance of one mile.Through it, the " +
                                 "caster can see and hear as though he were present, but doing so overwhelms " +
                                 "his body’s senses, and he can only perceive the world through the Spy of Light. " +
                                 "Each combat turn the caster decides if he will see through the Spy of Light, or " +
                                 "his own senses. The Spy of Light has an ability of 100 at Notice and Search. If " +
                                 "attacked, it can defend itself with the Magic Projection of its caster. For purposes " +
                                 "of Initiative, it acts when its controller does.It is only possible to attack it with " +
                                 "supernatural attacks, although it is destroyed if it receives any damag",
                        AddedEffect = "+5 to Notice and Search and +1 mile to range",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 5 (20)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Ecstasy",
                        Action = SpellAction.Active,
                        Level = 38,
                        Cost = 60,
                        Effect = "This spell intoxicates anyone affected with a feeling of utter ecstasy. The " +
                                 "sensation of pleasure is so powerful that the victim’s senses are completely clouded, " +
                                 "and he receives a –20 All Action Penalty while affected.However, the spell’s victims " +
                                 "are also completely oblivious and immune to any pain or other affliction based " +
                                 "penalty, except those for actually being physically incapacitated.The MR Check to " +
                                 "resist this spell has a Difficulty of 80, and affects a radius of 30 feet",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Banish Negative Emotions",
                        Action = SpellAction.Active,
                        Level = 40,
                        Cost = 80,
                        Effect = "Temporarily banishes any negative sentiments such as hatred, fear, or " +
                                 "anger within 300 feet of the caster. Resisting the spell requires beating a MR or " +
                                 "PsR Check with a Difficulty of 100",
                        AddedEffect = "+150 feet to radius and +5 to MR or PsR Difficulty",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 100
                            },
                            new Resistance
                            {
                                Type = ResistanceType.Psychic,
                                Value = 100
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Healing Light",
                        Action = SpellAction.Active,
                        Level = 42,
                        Cost = 80,
                        Effect = "Causes whomever the spell is directed at to recover 40 Life Points. " +
                                 "This spell does not restore permanently lost or destroyed limbs, nor eliminate " +
                                 "penalties caused by Critical attack",
                        AddedEffect = "+5 Life Points",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Seeking Sphere",
                        Action = SpellAction.Active,
                        Level = 46,
                        Cost = 120,
                        Effect = "Unleashes a sphere of luminous energy with Base Damage of 100. The " +
                                 "caster can control it using his Magic Projection until it hits its target. If the target " +
                                 "successfully dodges, the Seeking Sphere can continue attacking the following turn, " +
                                 "since it has not been destroyed.When Seeking Sphere causes damage, or is blocked, " +
                                 "the Sphere explodes and vanishes.If the caster abandons control of it, it will act " +
                                 "independently, following its last designated target with a Magic Projection of 150",
                        AddedEffect = "+5 to Base Damage and +5 to the Magic Projection of the Seeking Sphere",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (12)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Attack
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Zone of Detection",
                        Action = SpellAction.Active,
                        Level = 48,
                        Cost = 140,
                        Effect = "This spell allows the caster to detect any being within the area of the " +
                                 "spell who does not beat a MR Check with a Difficulty of 180. The Zone of " +
                                 "Detection only tells the caster how many individuals are in the zone, and their " +
                                 "exact location. It also senses spells of Detection that attempt to enter into the " +
                                 "area, as long as the spellcaster using them does not beat the MR(regardless of " +
                                 "his actual location). The affected zone can be no larger than 60 feet in radius, " +
                                 "and is stationary in the place it was cast",
                        AddedEffect = "+30 feet to radius and +10 to MR Difficulty",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (7)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Detection
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 180
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Enter Another’s Dreams",
                        Action = SpellAction.Active,
                        Level = 50,
                        Cost = 120,
                        Effect = "This allows the caster to physically enter a sleeper’s dreams. The caster " +
                                 "has no control over the dream world of the dreamer, and anything that happens " +
                                 "there will be real to the caster. The person must have peaceful dreams to be " +
                                 "affected by this spell, and the moment the dream turns into a nightmare, or he " +
                                 "awakens or dies, the mage abandons the dream world and returns to reality. " +
                                 "Any Spiritual spell cast on the dreamer while the caster is present in his dreams " +
                                 "will also affect the caster.The MR or PsR Check has a Difficulty of 140.Once " +
                                 "he is in the target person’s dreams, the caster can jump to the unconscious of " +
                                 "yet another dreamer who is physically no more than 30 feet from the original " +
                                 "sleeper.Naturally, this new dreamer will have the right to his own MR Check. " +
                                 "If the dreamer’s consciousness happens to be in the world of The Wake, the " +
                                 "caster is trapped there even when the spell expires",
                        AddedEffect = "+30 feet additional to jumping range and +5 to MR or PsR Difficulty",
                        MaximumZeon = "20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (6)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 140
                            },
                            new Resistance
                            {
                                Type = ResistanceType.Psychic,
                                Value = 140
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Light Form",
                        Action = SpellAction.Active,
                        Level = 52,
                        Cost = 100,
                        Effect = "The body designated by the caster is transformed to pure luminous " +
                                 "energy and becomes intangible to matter and non-energy attacks. While in " +
                                 "this state, the transformed person gains a +50 bonus to his abilities of Notice " +
                                 "and Search, and a +30 to his Resistance against effects based on Light. In this " +
                                 "state, the damage caused by Darkness based attacks is doubled. The maximum " +
                                 "Presence that can be affected is 100",
                        AddedEffect = "+10 to the maximum Presence that can be affected",
                        MaximumZeon = "10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (10)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfDarkness()
        {
            return new BookOfDarkness
            {
                Name = "Book of Darkness",
                School = "Darkness",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfCreation()
        {
            return new BookOfCreation
            {
                Name = "Book of Creation",
                School = "Creation",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfDestruction()
        {
            return new BookOfDestruction
            {
                Name = "Book of Destruction",
                School = "Destruction",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfAir()
        {
            return new BookOfAir
            {
                Name = "Book of Air",
                School = "Air",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfWater()
        {
            return InterfaceFactory
                .New()
                .WithValues(new
            {
                Id = Identification.BookOfWater,
                Name = "Book of Water",
                School = "Water",
                Spells = new[]
                {
                    new
                    {
                        Id = "Spring",
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            }).Build<ICoreSpellBook>();

            //return new BookOfWater
            //{
            //    Name = "Book of Water",
            //    School = "Water",
            //    Spells = new[]
            //    {
            //        new CoreSpell
            //        {
            //            Name = "Spring",
            //            Action = SpellAction.Active,
            //            Level = 2,
            //            Cost = 30,
            //            Effect = "This spell draws forth any nearby underground current or stream, " +
            //                     "causing a spring to flow from the spot designated by the caster. The spell " +
            //                     "affects natural liquids within 300 feet of the character casting the spell, but it " +
            //                     "can not overcome energy barriers",
            //            AddedEffect = "+100 feet to radius.",
            //            MaximumZeon = "x20",
            //            ZeonAttribute = CharacterAttribute.Int,
            //            Maintenance = "1 every 10 (3)",
            //            MaintenanceDuration = MaintenanceDuration.Daily,
            //            Type = new[]
            //            {
            //                SpellType.Effect
            //            },
            //            Tags = new[]
            //            {
            //                Tag.Area
            //            }
            //        }
            //    }
            //};
        }

        public static ICoreSpellBook GetBookOfFire()
        {
            return new BookOfFire
            {
                Name = "Book of Fire",
                School = "Fire",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfEarth()
        {
            return new BookOfEarth
            {
                Name = "Book of Earth",
                School = "Earth",
                Spells = new[]
                {
                    new CoreSpell
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
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Mineral Control",
                        Action = SpellAction.Active,
                        Level = 6,
                        Cost = 30,
                        Effect = "This spell enables the caster to move, reshape, and control any mineral " +
                                 "substance with a Presence of 30 or lower. However, the caster cannot endow " +
                                 "a mineral with capacities it does not already possess. In other words, the caster " +
                                 "may reshape a pebble into an arrowhead, but he could not make it inflict " +
                                 "electrical damage. Some golems and stone elementals can be controlled with " +
                                 "this spell. Mineral based creatures may avoid the effect of this spell by passing " +
                                 "a MR Check with a Difficulty of 100. The control check must be repeated " +
                                 "immediately if the creature is given an order completely opposed to its nature",
                        AddedEffect = "+10 to the maximum Presence affected and +5 to MR Difficulty",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect,
                            SpellType.Spiritual
                        },
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
                            Tag.Self,
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Weight Increment",
                        Action = SpellAction.Active,
                        Level = 10,
                        Cost = 40,
                        Effect = "It increases a physical body’s weight by 20 kg",
                        AddedEffect = "+10 kg",
                        MaximumZeon = "x30",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (4)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Transform Mineral",
                        Action = SpellAction.Passive,
                        Level = 12,
                        Cost = 40,
                        Effect = "This spell changes one type of material into another, modifying its " +
                                 "natural composition. It can affect rocks and metals with a base Presence " +
                                 "not higher than 30. For instance, it can turn a piece of limestone into a " +
                                 "gold nugget. It can transform up to 20 pounds of material",
                        AddedEffect = "+5 to the maximum Presence affected and +20 pounds",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (2)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Firmness",
                        Action = SpellAction.Active,
                        Level = 16,
                        Cost = 50,
                        Effect = "This spell enhances the endurance of " +
                                 "individuals or objects, making them more " +
                                 "resistant to damage. When cast upon a " +
                                 "living organism, it grants a +20 bonus to " +
                                 "any PhR Check to avoid the effects of a " +
                                 "Critical. On the other hand, when applied " +
                                 "to an object with Fortitude, it increases it " +
                                 "by +2. Each Firmness spell can affect only " +
                                 "one body or object at a time",
                        AddedEffect = "+5 to PhR or +1 to Fortitude",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Stone Barrier",
                        Action = SpellAction.Passive,
                        Level = 20,
                        Cost = 60,
                        Effect = "This spell raises a material barrier allowing " +
                                 "the spellcaster to repel any damaging attacks including " +
                                 "those based on energy. However, this shield is unable " +
                                 "to stop Spiritual effects that only call for MR or PsR. " +
                                 "The spell can take up to 600 points before being broken, but " +
                                 "it has a Damage Barrier of 60 against physical attacks",
                        AddedEffect = "+100 Resistance Points and +5 to Damage Barrier",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Defense
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Slowness",
                        Action = SpellAction.Active,
                        Level = 22,
                        Cost = 60,
                        Effect = "This spell decreases motion and reaction speed of the " +
                                 "selected individual. If the affected character does not pass a MR " +
                                 "with a Difficulty of 120, his Initiative decreases by 50 points and a " +
                                 "–2 penalty is applied to his Movement Value",
                        AddedEffect = "+5 to MR Difficulty, –5 to Initiative and –1 to Movement Value",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Shell",
                        Action = SpellAction.Active,
                        Level = 26,
                        Cost = 80,
                        Effect = "This spell creates a physical shell with an AT 2 against all kinds of attack, " +
                                 "except energy-based attacks. Even though it is considered armor, no penalties " +
                                 "are applied to the turn Initiative for using extra protection layers",
                        AddedEffect = "+1 to Armor Type",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 5 (16)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Magnetic Shield",
                        Action = SpellAction.Passive,
                        Level = 30,
                        Cost = 50,
                        Effect = "By controlling magnetic fields around " +
                                 "him, the spellcaster raises a shield with the " +
                                 "ability of repelling any attack of a metallic " +
                                 "nature made against him, including bullets and " +
                                 "arrows and darts with metal tips. The shield’s " +
                                 "magnetism causes a distortion that results in a " +
                                 "–50 penalty to the attacker’s offensive ability. " +
                                 "The shield will take up to 300 damage points " +
                                 "before being broken, but it will only be affected " +
                                 "by energy damaging attacks. This barrier is virtually " +
                                 "useless against immaterial or Spiritual attacks",
                        AddedEffect = "+100 Resistance Points",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (5)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Defense
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Pass Through Solid Matter",
                        Action = SpellAction.Active,
                        Level = 32,
                        Cost = 80,
                        Effect = "This spell enables one or more subjects, as appointed by " +
                                 "the spellcaster, to pass through solid objects. The recipients of the spell do " +
                                 "not exactly become immaterial, as they are still affected by heat or cold, " +
                                 "but they can completely ignore all things non-energy based.In this way, " +
                                 "characters can decide to pass through anything from walls to sword blades as " +
                                 "if they did not exist.It is possible for the caster to determine what materials " +
                                 "can be passed through and which cannot.The maximum total Presences that " +
                                 "can be affected may not exceed 100",
                        AddedEffect = "+10 to the maximum Presence",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (4)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Earth Spike",
                        Action = SpellAction.Active,
                        Level = 36,
                        Cost = 80,
                        Effect = "Giant stone spikes erupt from the ground and impale targets on " +
                                 "the surface. The spell allows for a maximum of two spikes, each " +
                                 "with a 60 point Base Damage in the Thrust Attack " +
                                 "Type; they cannot affect immaterial beings, or those " +
                                 "only damaged by energy, unless Earth Spike is combined " +
                                 "with an Enchant spell.Each spike may be used to attack the " +
                                 "same, or different targets.This spell cannot be employed to perform " +
                                 "a spell clash",
                        AddedEffect = "One additional spike",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Attack
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Breakage",
                        Action = SpellAction.Active,
                        Level = 40,
                        Cost = 60,
                        Effect = "This magically increases a targeted object’s or weapon’s breakage by " +
                                 "four points",
                        AddedEffect = "+1 to the object’s Breakage",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (6)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Telemetry",
                        Action = SpellAction.Active,
                        Level = 42,
                        Cost = 120,
                        Effect = "This spell allows the caster to read the story of an object or person he " +
                                 "comes into contact with, including the most important events in which it has " +
                                 "been involved during the past year. Individuals have the chance of repelling the " +
                                 "spell if they pass a MR with a Difficulty of 80",
                        AddedEffect = "+5 to MR Difficulty and an additional year",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances = new[]
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Magic,
                                Value = 80
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Magnetic Control",
                        Action = SpellAction.Active,
                        Level = 46,
                        Cost = 100,
                        Effect = "This spell grants control over the surrounding magnetic fields in an 80-" +
                                 "foot radius, allowing the caster to freely move any metallic body with a force " +
                                 "equivalent to Strength 13. Magnetism control is such that actions are executed " +
                                 "as an automatic effect on metal. For instance, a character using this spell could " +
                                 "paralyze someone on a full armor, or snatch the sword out of his hands.In " +
                                 "these cases, it is possible to avoid such effects by passing an opposed Strength or " +
                                 "Agility Check.This control is an active action, therefore the caster must have the " +
                                 "action in order to perform it, and consequently this cannot be used as a defense. " +
                                 "Against objects or creatures only partially composed of metals, or those that are " +
                                 "energy shielded, the control is reduced to Strength 8",
                        AddedEffect = "+80 feet to radius",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (10)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Forge",
                        Action = SpellAction.Active,
                        Level = 50,
                        Cost = 160,
                        Effect = "This spell employs magic with the purpose of forging objects, using the " +
                                 "equivalent of a Forging ability of 100. Since the action is based on supernatural " +
                                 "powers, none of the time modifiers in Table 17 apply, and no forging " +
                                 "equipment is required. This spell does not produce the materials, such as steel, " +
                                 "needed for creating specific items; the spellcaster must provide them",
                        AddedEffect = "+5 to Forging ability",
                        MaximumZeon = "30",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Solid Body",
                        Action = SpellAction.Active,
                        Level = 52,
                        Cost = 100,
                        Effect = "The targeted body becomes immensely solid with stone-like resistance. " +
                                 "When cast upon individuals, they receive a natural armor Type 6 (except against " +
                                 "energy) and a Damage Barrier of 100. The character’s muscles strengthen for " +
                                 "as long as he remains in this state, increasing his Strength characteristic by 2 and " +
                                 "decreasing his Movement Value by 2.The transformed body resembles a different " +
                                 "material depending on the additions employed in the spell; iron, granite, steel, " +
                                 "diamonds, etc.The maximum Presence that can be affected is 100",
                        AddedEffect =
                            "+10 to the maximum Presence affected, +1 to natural AT and +10 to Damage Barrier",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (10)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Resistance",
                        Action = SpellAction.Active,
                        Level = 56,
                        Cost = 100,
                        Effect = "This spell confers the temporary ability to absorb almost any damage " +
                                 "inflicted on an individual. It provides 500 additional Life Points, which allow " +
                                 "the targeted individual to use the defense rules of Damage Resistance beings. " +
                                 "These extra LP are subtracted before any of the target’s actual LP. Its Armor " +
                                 "Type depends on the character’s size, as it is described in Chapter 26. The " +
                                 "target of this spell cannot use any defense abilies for as long as the spell is " +
                                 "maintained.Resistance spells affect only one individual at a time",
                        AddedEffect = "+50 extra LP",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (10)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Petrify",
                        Action = SpellAction.Active,
                        Level = 60,
                        Cost = 140,
                        Effect = "This spell transforms a physical being into a stone statue. The targeted " +
                                 "individual cannot move and has no awareness of the events going on around " +
                                 "him for the duration of the spell.This spell can be maintained for years, but the " +
                                 "affected being does not age.As soon as the spell ends, the individual returns to " +
                                 "his original condition.Any damage or breakage inflicted upon the statue may " +
                                 "result in damage, or even death, of the actual character.The tatget of this spell " +
                                 "can resist its affects by passing a MR Check of 120 Difficulty.A subject affected " +
                                 "by a Petrify spell is entitled to a reroll after the first day he has been affected, " +
                                 "and later, once a week",
                        AddedEffect = "+5 to MR Difficulty",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (7)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Fissure",
                        Action = SpellAction.Active,
                        Level = 62,
                        Cost = 150,
                        Effect = "This spell casues a violent, but highly concentrated tremor that splits " +
                                 "open the earth, creating a fissure 10 feet wide, 30 feet long, and 60 – 150 " +
                                 "feet deep. Individuals in the area of the fissure must pass an Agility Check to " +
                                 "avoid falling inside and suffering the appropriate impact damage. Constructions " +
                                 "in the area of the fissure can also be severely damage, but any stucture with " +
                                 "a Damage Barrier higher than 40 is not be affected by this spell, since their " +
                                 "structure is too dense",
                        AddedEffect = "+10 feet long, +3 feet wide and +5 to Damage Barrier of constructions affected",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Reverse Gravity",
                        Action = SpellAction.Active,
                        Level = 66,
                        Cost = 200,
                        Effect = "This spell completely alters gravity in a particular area of the planet, " +
                                 "reversing its force. In a way, it turns the world upside down. Everything " +
                                 "encompassed within an 80-foot radius immediately starts to “fall” into the sky " +
                                 "up to a maximum distance of 150 feet. The caster may set limits on this spell, " +
                                 "such as only affecting the interior of a designated structure. Naturally, objects " +
                                 "rooted or otherwise fixed to the ground will not fall. Individuals may avoid the " +
                                 "effects of the spell by passing a MR Check with a Difficulty of 120.The area of " +
                                 "effect remains stationary",
                        AddedEffect = "+30 meters to radius and height",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 5 (40)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Mineral Creation",
                        Action = SpellAction.Active,
                        Level = 70,
                        Cost = 120,
                        Effect = "The spellcaster may use this spell to create anything he wishes, " +
                                 "provided it is composed of minerals or metal. The created object cannot " +
                                 "have a Presence higher than 40, and it must appear in a logical location " +
                                 "according to its nature",
                        AddedEffect = "+5 to the maximum Presence of the created object",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (12)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Terrain Erudition",
                        Action = SpellAction.Active,
                        Level = 72,
                        Cost = 120,
                        Effect = "The caster gains immediate and total knowledge of everything in " +
                                 "contact with the ground for several miles around him.Both constructions " +
                                 "and living creatures can be detected straightaway, provided they are not " +
                                 "immaterial. This spell does not affect energy-sealed places.Terrain Erudition " +
                                 "covers a 1,200 foot radius around the caster",
                        AddedEffect = "+600 feet to radius",
                        MaximumZeon = "x30",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "No",
                        MaintenanceDuration = MaintenanceDuration.None,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Self,
                            Tag.Area
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Earthquake",
                        Action = SpellAction.Active,
                        Level = 76,
                        Cost = 150,
                        Effect = "This spell causes a devestating tremor in a 1,600-foot radius with " +
                                 "enough potential force to destroy a city. Any construction with a Damage " +
                                 "Barrier lower than 40 is be immediately destroyed, while the rest suffer 5 " +
                                 "points of damage in the first round; this damage is doubled every subsequent " +
                                 "round(10 in the second, 20 in the third, etc.).Constructions with a " +
                                 "Damage Barrier higher than 150 are not be affected by the earthquake at " +
                                 "all. All individuals inside the spell zone suffer the appropriate effects from " +
                                 "falling debris, depending on their surrounding",
                        AddedEffect = "+800 feet to radius",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (15)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances =
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Gravity Destruction",
                        Action = SpellAction.Active,
                        Level = 80,
                        Cost = 180,
                        Effect = "This spell creates a high pressure gravity bubble that can trap any " +
                                 "physical entity and damage it to the point it bursts. Trapped creatures must pass " +
                                 "a PhR with a Difficulty of 180 every round, or be subject to damage equal to " +
                                 "half the failure level. The victim receives a +5 bonus to the PhR roll for every AT " +
                                 "point against Impact.The extreme pressure prevents the target from escaping " +
                                 "the area of effect unless it passes an Opposed Check against a Strength of " +
                                 "16. The power of gravity is so strong that even immaterial beings are partially " +
                                 "affected by it, although they can apply a + 40 bonus to their Resistance controls " +
                                 "and + 6 to Strength.The spell affects everything in a 60-foot radius except for " +
                                 "the caster. The area of effect remains stationary",
                        AddedEffect = "+15 feet to radius",
                        MaximumZeon = "x20",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 10 (18)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
                        Resistances = new []
                        {
                            new Resistance
                            {
                                Type = ResistanceType.Physical,
                                Value = 180
                            }
                        },
                        Tags = new[]
                        {
                            Tag.Area,
                            Tag.Target
                        }
                    },
                }
            };
        }

        public static ICoreSpellBook GetBookOfEssence()
        {
            return new BookOfEssence
            {
                Name = "Book of Essence",
                School = "Essence",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    }
                }
            };
        }

        public static ICoreSpellBook GetBookOfIllusion()
        {
            return new BookOfIllusion
            {
                Name = "Book of Illusion",
                School = "Illusion",
                Spells = new[]
                {
                    new CoreSpell
                    {
                        Name = "Illusory Sound",
                        Action = SpellAction.Active,
                        Level = 2,
                        Cost = 30,
                        Effect = "This spell allows the caster to create any sound, including human " +
                                 "voices, in a 60-foot radius area. All subjects within the area of effect must " +
                                 "pass a MR check with a Difficulty of 100 to disbelieve the effect, though the " +
                                 "spellcaster may choose which specific characters hear the illusion.",
                        AddedEffect = "+30 feet to radius and +5 to MR Difficulty.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 50 (1)",
                        MaintenanceDuration = MaintenanceDuration.Turn,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Detection
                        },
                        Tags = new[]
                        {
                            Tag.Self
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Resistances = new Resistance[]
                        {
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Detection
                        },
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
                            Tag.Target,
                            Tag.Area
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Spiritual
                        },
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
                            Tag.Target
                        }
                    },
                    new CoreSpell
                    {
                        Name = "Create Illusory Being",
                        Action = SpellAction.Active,
                        Level = 40,
                        Cost = 60,
                        Effect = "This spell creates a first-level illusory being. " +
                                 "The entity is fashioned according to the caster’s desires, " +
                                 "using the rules set forth in Chapter 26 for Beings Between " +
                                 "Worlds. However, the illusory being’s nature automatically " +
                                 "grants it the Physical Exemption ability. " +
                                 "Because the creature is not real, it can not inflict damage or affect " +
                                 "physical reality whatsoever. All non - Energy based attacks pass right " +
                                 "through it without damaging it in any way. This spell must be cast " +
                                 "upon a specific area not exceeding a radius of 60 feet. Those characters " +
                                 "entering the spell’s area of effect must pass a MR Check with a Difficulty of " +
                                 "120 to avoid it. Even though the spell is circumscribed to a specific zone, the " +
                                 "illusory creature can leave that area while chasing after a subject affected " +
                                 "by the spell. However, it remains unseen by anyone not previously inside the spell’s " +
                                 "area. Keep in mind that those subjects who pass the MR Check do not exist to the " +
                                 "illusory creature, and it will ignore them. Illusions may have a maximum of two " +
                                 "levels more than the caster.",
                        AddedEffect = "+5 to MR, +1 to the created being’s level and +5 feet to radius.",
                        MaximumZeon = "x10",
                        ZeonAttribute = CharacterAttribute.Int,
                        Maintenance = "1 every 20 (3)",
                        MaintenanceDuration = MaintenanceDuration.Daily,
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Effect
                        },
                        Tags = new[]
                        {
                            Tag.Target
                        }
                    },
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Automatic
                        },
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

        public static ICoreSpellBook GetBookOfNecromancy()
        {
            return new BookOfNecromancy
            {
                Name = "Book of Necromancy",
                School = "Necromancy",
                Spells = new[]
                {
                    new CoreSpell
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
                        Type = new[]
                        {
                            SpellType.Detection
                        },
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