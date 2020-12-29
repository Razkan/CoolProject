namespace Interfaces.Model.Book.Spell
{
    public interface IFreeSpell : ISpell
    {
        string LevelRange { get; }
    }
}