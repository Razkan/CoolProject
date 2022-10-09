using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Mage.Enum;

namespace Interfaces.Model.Mage.Arcanum.Spell
{
    [TableInterface]
    public interface ISchoolEffect : IDatabaseEntity
    {
        School School { get; }
        long Level { get; }
        string Effect { get; }
    }
}