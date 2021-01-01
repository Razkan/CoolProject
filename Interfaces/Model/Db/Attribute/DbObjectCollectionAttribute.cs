using System;

namespace Interfaces.Model.Db.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbObjectCollectionAttribute : System.Attribute
    {
        public DbObjectCollectionAttribute(params object[] args)
        {
        }
    }
}