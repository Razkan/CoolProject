using System;

namespace Interfaces.Model.Db.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbPrimitiveCollectionAttribute : System.Attribute
    {
        public DbPrimitiveCollectionAttribute(params object[] args)
        {
        }
    }
}