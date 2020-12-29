using System;

namespace Library
{
    public class EndpointAttribute : Attribute
    {
        public Uri Uri { get; }

        public EndpointAttribute(string uri)
        {
            Uri = new Uri(uri);
        }
    }
}