using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;
using Interfaces.Model.Enum;

namespace Interfaces.Model.Book.Spell
{
    [TableInterface]
    public interface IResistance : IDatabaseEntity
    {
        ResistanceType Type { get; }
        long Value { get; }
    }
}