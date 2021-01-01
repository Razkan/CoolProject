using System;

namespace Interfaces.Model
{
    public interface IStorage
    {
        void Store(string @interface, Uri uri);
        IFetch Get(string @interface);
    }
}