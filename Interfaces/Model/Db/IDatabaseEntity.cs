using System.Text.Json.Serialization;
using Interfaces.Model.Db.Attribute;

namespace Interfaces.Model.Db
{
    public interface IDatabaseEntity
    {
        [JsonIgnore]
        [PrimaryKey]
        string Id { get; }
    }
}