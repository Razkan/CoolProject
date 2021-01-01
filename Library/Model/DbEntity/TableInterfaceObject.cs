using Interfaces.Model.Db.Attribute;

namespace Library.Model.DbEntity
{
    public class TableInterfaceObject
    {
        [PrimaryKey]
        public string Id { get; set; } // Id of realEntity
        public string Type { get; set; } // string to the actual table
    }
}