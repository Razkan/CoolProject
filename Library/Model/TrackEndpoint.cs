using System;
using Interfaces.Model.Shared;

namespace Library.Model
{
    public class TrackEndpoint : ITrackEndpoint
    {
        public string TInterface { get; set; }
        public Uri Uri { get; set; }
    }
}