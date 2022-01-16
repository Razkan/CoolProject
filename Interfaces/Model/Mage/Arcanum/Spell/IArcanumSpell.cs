using System.Collections.Generic;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Mage.Enum;
using Interfaces.Model.Shared;

namespace Interfaces.Model.Mage.Arcanum.Spell
{
    [TableInterface]
    public interface IArcanumSpell : IDatabaseEntity
    {
        string Name { get; }
        string Effect { get; }
        long Level { get; }

        Practice Practice { get; }
        PrimaryFactor PrimaryFactor { get; }
        Withstand Withstand { get; }

        [DbPrimitiveCollection]
        IEnumerable<RoteSkills> SuggestedRoteSkills { get; }

        [DbObjectCollection]
        IEnumerable<IReachEffect> ReachEffects { get; }

        [DbObjectCollection]
        IEnumerable<ISchoolEffect> SchoolEffects { get; }

        [DbPrimitiveCollection]
        IEnumerable<Tag> Tags { get; }
    }
}