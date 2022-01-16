using System;

namespace Interfaces.Model.Shared
{
    public interface ITrackEndpoint
    {
        string TInterface { get; }
        Uri Uri { get; }
    }
}