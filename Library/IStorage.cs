using System;
using Interfaces.Model;

namespace Library
{
    public interface IStorage
    {
        void Store(string @interface, Uri uri);
        IFetch Get(string @interface);
    }
}