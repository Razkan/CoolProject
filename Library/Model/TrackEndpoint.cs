using System;
using Interfaces.Model;

namespace Library.Model
{
    public class TrackEndpoint : ITrackEndpoint
    {
        public string TInterface { get; set; }
        public Uri Uri { get; set; }
    }
}