using Interfaces.Model.Anima.Enum;
using Interfaces.Model.Db;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Anima.Book.Spell
{
    [TableInterface]
    public interface IResistance : IDatabaseEntity
    {
        ResistanceType Type { get; }
        long Value { get; }
    }
}