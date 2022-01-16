using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Mage.Arcanum.Spell
{
    [TableInterface]
    public interface IReachEffect : IDatabaseEntity
    {
        long Reach { get; }
        string Effect { get; }
    }
}