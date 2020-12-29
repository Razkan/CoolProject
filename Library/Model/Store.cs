using System;
using Interfaces.Model;

namespace Library.Model
{
    public class Store : IStore
    {
        public string TInterface { get; set; }
        public Uri Uri { get; set; }
    }
}