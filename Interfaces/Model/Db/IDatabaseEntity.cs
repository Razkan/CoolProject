using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Db
{
    public interface IDatabaseEntity
    {
        [PrimaryKey]
        string Id { get; }
    }
}