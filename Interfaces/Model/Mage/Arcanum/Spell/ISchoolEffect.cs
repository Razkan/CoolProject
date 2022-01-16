using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Mage.Arcanum.Spell
{
    [TableInterface]
    public interface ISchoolEffect : IDatabaseEntity
    {
        string School { get; }
        long Level { get; }
        string Effect { get; }
    }
}