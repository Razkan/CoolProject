using System;

namespace Interfaces.Model
{
    public interface ITrackEndpoint
    {
        string TInterface { get; }
        Uri Uri { get; }
    }
}