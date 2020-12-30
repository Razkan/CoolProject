using Interfaces.Model.Enum;

namespace Interfaces.Model.Book.Spell
{
    public interface IResistance
    {
        ResistanceType Type { get; }
        long Value { get; }
    }
}