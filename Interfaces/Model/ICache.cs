using System;

namespace Interfaces.Model
{
    public interface ICache
    {
        void Store(string @interface, Uri uri);
        IEndpoint Get(string @interface);
    }
}